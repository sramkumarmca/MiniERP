(function () {
    'use strict';

    angular
        .module('spitfire')
        .controller('MainCustomersDialogInstanceController', MainCustomersDialogInstanceController);

    MainCustomersDialogInstanceController.$inject = ['$modalInstance', 'User'];

    function MainCustomersDialogInstanceController($modalInstance, User) {
        var vm = this;

        vm.customer = new User();

        vm.save = function () {
            vm.showError = false;

            if (vm.customerForm.$valid) {
                User.save(vm.customer)
                    .$promise
                    .then(function (savedCustomer) {
                        $modalInstance.close(savedCustomer);
                    })
                    .catch(function (error) {
                        vm.showError = true;
                        vm.errorMessage = error.data.title;
                    });
            }
        };

        vm.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }
})();
