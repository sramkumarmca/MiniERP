(function () {
    'use strict';

    angular
        .module('spitfire')
        .controller('MainCustomersEditCustomerDialogController', MainCustomersEditCustomerDialogController);

    MainCustomersEditCustomerDialogController.$inject = ['$modalInstance', '$q', 'User', 'user'];

    function MainCustomersEditCustomerDialogController($modalInstance, $q, User, user) {
        var vm = this;
        vm.cancel = cancel;

        vm.customer = user;

        function cancel() {
            $modalInstance.dismiss('cancel');
        }
    }
})();
