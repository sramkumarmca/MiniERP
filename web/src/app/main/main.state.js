'use strict';

(function () {
    angular
        .module('spitfire')
        .config(stateConfiguration);

    var stateSettings = {
        name: 'main',
        state: {
            abstract: true,
            templateUrl: 'app/main/main.html',
            controller: 'MainController as main'
        },
        breadcrumb: {
            titleTranslationId: 'main.breadcrumb',
            url: '/'
        },
        translations: 'app/main'
    };

    stateSettings.state.onEnter = onEnter;
    stateSettings.state.onExit = onExit;

    stateConfiguration.$inject = ['$stateProvider'];

    function stateConfiguration($stateProvider) {
        $stateProvider.state(stateSettings.name, stateSettings.state);
    }

    onEnter.$inject = ['titleService', 'breadcrumbsService', 'sidebarService'];

    function onEnter(titleService, breadcrumbsService, sidebarService) {
        titleService.clearTitle();

        setupSidebarShortcuts(sidebarService);
        setupSidebarItems(sidebarService);

        breadcrumbsService.addBreadcrumb(stateSettings.breadcrumb);
    }

    onExit.$inject = ['titleService', 'breadcrumbsService', 'sidebarService'];

    function onExit(titleService, breadcrumbsService, sidebarService) {
        titleService.clearTitle();

        sidebarService.clearShortcuts();
        sidebarService.clearItems();

        breadcrumbsService.removeLastBreadcrumb();
    }

    if (stateSettings.translations) {
        stateSettings.state.resolve = stateSettings.state.resolve || {};
        stateSettings.state.resolve.translations = refreshTranslations;
    }

    refreshTranslations.$inject = ['$translatePartialLoader', '$translate'];

    function refreshTranslations($translatePartialLoader, $translate) {
        $translatePartialLoader.addPart(stateSettings.translations);
        return $translate.refresh();
    }

    function setupSidebarShortcuts(sidebarService) {
        sidebarService.setShortcuts([
            {
                titleTranslationId: 'sidebar.shortcuts.statistics',
                buttonClass: 'btn btn-success',
                icon: 'icon-signal',
                click: function () {
                    window.alert('Going to the statistics page ...');
                }
            },
            {
                titleTranslationId: 'sidebar.shortcuts.profile',
                buttonClass: 'btn btn-warning',
                icon: 'icon-group',
                click: function () {
                    window.alert('Going to the profile page ...');
                }
            },
            {
                titleTranslationId: 'sidebar.shortcuts.administration',
                buttonClass: 'btn btn-danger',
                icon: 'icon-cogs',
                click: function () {
                    window.alert('Going to the administration page ...');
                }
            }
        ]);
    }

    function setupSidebarItems(sidebarService) {
        sidebarService.setItems([
            {
                key: 'main.dashboard',
                titleTranslationId: 'sidebar.items.main.dashboard',
                icon: 'icon-home',
                state: 'main.dashboard'
            },
            {
                key: 'main.customers',
                titleTranslationId: 'sidebar.items.main.customers',
                icon: 'icon-group',
                state: 'main.customers'
            },
            {
                key: 'main.suppliers',
                titleTranslationId: 'sidebar.items.main.suppliers',
                icon: 'icon-truck',
                state: 'main.suppliers'
            },
            {
                key: 'main.contacts',
                titleTranslationId: 'sidebar.items.main.contacts',
                icon: 'icon-envelope',
                state: 'main.contacts'
            },
            {
                key: 'main.offers',
                titleTranslationId: 'sidebar.items.main.offers',
                icon: 'icon-book',
                state: 'main.offers'
            },
            {
                key: 'main.invoices',
                titleTranslationId: 'sidebar.items.main.invoices',
                icon: 'icon-credit-card',
                state: 'main.invoices'
            },
            {
                key: 'main.about',
                titleTranslationId: 'sidebar.items.main.about',
                icon: 'icon-circle-blank',
                state: 'main.about'
            }// ======= yeoman sidebar hook =======
             // Note: Do not remove the above hook if you wish the sidebar to remain working
        ]);
    }
})();
