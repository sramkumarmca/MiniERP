(function () {
    'use strict';

    angular
        .module('spitfire')
        .controller('MainCustomersEditCustomerDialogController', MainCustomersEditCustomerDialogController);

    MainCustomersEditCustomerDialogController.$inject = ['$modalInstance', '$q', 'User', 'user'];

    function MainCustomersEditCustomerDialogController($modalInstance, $q, User, user) {
        var vm = this;
        var originalName = user.name;

        vm.save = save;
        vm.cancel = cancel;
        vm.validateUsername = validateUsername;

        vm.customer = user;

        function save() {
            vm.showError = false;

            if (vm.customerForm.$valid) {
                User.update({ userName: originalName }, vm.customer)
                    .$promise
                    .then(function (savedCustomer) {
                        $modalInstance.close(savedCustomer);
                    })
                    .catch(function (error) {
                        vm.showError = true;
                        vm.errorMessage = error.data.title;
                    });
            }
        }

        function cancel() {
            $modalInstance.dismiss('cancel');
        }

        function validateUsername() {
            if (angular.isUndefined(vm.customer.name)) {
                return {
                    unique: true
                };
            }

            // If nothing has changed to the name, all is fine
            if (vm.customer.name === originalName) {
                return {
                    unique: true
                };
            }

            var uniqueDeferred = $q.defer();
            User.get({
                userName: vm.customer.name
            }).$promise.then(function (user) {
                uniqueDeferred.resolve(false);
            }, function (errResponse) {
                // handle 404 here
                uniqueDeferred.resolve(true);
            });

            return {
                unique: uniqueDeferred.promise
            };
        }
    }
})();
