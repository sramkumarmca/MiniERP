'use strict';

(function () {
    angular
        .module('spitfire')
        .controller('MainCustomersController', MainCustomersController);

    MainCustomersController.$inject = ['$modal', '$translate', 'notification', 'User'];

    function MainCustomersController($modal, $translate, notification, User) {
        var vm = this;

        vm.openEditDialog = openEditDialog;
        vm.openNewDialog = openNewDialog;

        loadData();

        function loadData() {
            User.query(function (users) {
                vm.users = users;
            });
        }

        function openEditDialog(user) {
            var modalInstance = $modal.open({
                templateUrl: 'app/main/customers/customer-dialog.html',
                controller: 'MainCustomersEditCustomerDialogController as dialogVm',
                resolve: {
                    user: function () {
                        return user;
                    }
                }
            });
        }

        function openNewDialog() {
            var modalInstance = $modal.open({
                templateUrl: 'app/main/customers/customer-dialog.html',
                controller: 'MainCustomersNewCustomerDialogController as dialogVm'
            });

            modalInstance.result.then(function (newCustomer) {
                $translate(['main.customers.customerCreatedTitle', 'main.customers.customerCreatedText'])
                    .then(function (translations) {
                        notification.show({
                            title: translations['main.customers.customerCreatedTitle'],
                            text: translations['main.customers.customerCreatedText'],
                            type: 'success'
                        });
                    });

                loadData();
            });
        }
    }
})();
