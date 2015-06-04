'use strict';

(function () {
    angular
        .module('spitfire')
        .config(urlRouterConfiguration)
        .config(titleConfiguration)
        .config(authConfiguration);
        //.run(handleStateChangeError);

    var defaultPage = '/dashboard';

    titleConfiguration.$inject = ['titleServiceProvider'];

    function titleConfiguration(titleServiceProvider) {
        titleServiceProvider.setDefaultTitle({ text: '' });
        titleServiceProvider.setSeparator('-');

        titleServiceProvider.setPrefix({ text: 'Spitfire &raquo;' });
        titleServiceProvider.setSuffix({ text: '' });
    }

    urlRouterConfiguration.$inject = ['$urlRouterProvider'];

    function urlRouterConfiguration($urlRouterProvider) {
        // when there is an empty route, redirect to the default page
        $urlRouterProvider.when('', defaultPage)
                          .when('/', defaultPage);

        // when no matching route found redirect to error 404
        $urlRouterProvider.otherwise('/notfound');
    }

    authConfiguration.$inject = ['$httpProvider', 'adalAuthenticationServiceProvider'];

    function authConfiguration($httpProvider, adalAuthenticationServiceProvider) {
        //$httpProvider.interceptors.push('authenticationInterceptor');

        adalAuthenticationServiceProvider.init({
                tenant: 'd03a71e5-be37-42b3-b742-77b737634db8',
                clientId: 'e8643d3c-d1f5-4292-b3f2-db4eb7ec9f42',
                instance: 'https://login.microsoftonline.com/',
                //redirectUri : 'https://firmwarecsfrontend.azurewebsites.net/', // optional
                endpoints: {
                    'https://minierpsandboxapi.azurewebsites.net/api/': '5067f263-2017-4df4-97a1-c366304d3c9f',
                }
            },
            $httpProvider
        );
    }

    // handleStateChangeError.$inject = ['$rootScope', '$state', '$location', 'sessionService', 'unhandledErrorChannel'];
    //
    // function handleStateChangeError($rootScope, $state, $location, sessionService, unhandledErrorChannel) {
    //     $rootScope.$on('$stateChangeError',
    //         function (event, toState, toParams, fromState, fromParams, error) {
    //
    //             // unauthorized
    //             if (error.status === 401) {
    //                 event.preventDefault();
    //
    //                 // end the current session
    //                 sessionService.abandonSession();
    //
    //                 // go to login screen (only once!)
    //                 if (toState.name !== 'public.login') {
    //                     $location.url('/login').search({ 'redirect_state': toState.name });
    //                 }
    //             }
    //
    //             // forbidden
    //             else if (error.status === 403) {
    //                 event.preventDefault();
    //
    //                 // redirect to 'forbidden' error page
    //                 $state.go('main.forbidden');
    //             }
    //
    //                 // any other case
    //             else {
    //                 unhandledErrorChannel.errorOccurred(error);
    //             }
    //         });
    // }
})();
