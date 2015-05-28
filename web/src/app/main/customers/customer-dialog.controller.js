(function () {
    'use strict';

    angular
        .module('spitfire')
        .controller('MainCustomersDialogInstanceController', MainCustomersDialogInstanceController);

    MainCustomersDialogInstanceController.$inject = ['$modalInstance', '$q', 'User'];

    function MainCustomersDialogInstanceController($modalInstance, $q, User) {
        var vm = this;
        vm.save = save;
        vm.cancel = cancel;
        vm.validateUsername = validateUsername;

        vm.customer = new User();

        function save() {
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
