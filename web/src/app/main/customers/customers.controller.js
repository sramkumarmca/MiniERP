'use strict';

(function () {
    angular
        .module('spitfire')
        .controller('MainCustomersController', MainCustomersController);

    MainCustomersController.$inject = ['User'];

    function MainCustomersController(User) {
        var vm = this;

        User.query(function (users) {
            vm.users = users;
        });

        vm.view = function (user) {
            window.alert('Going to the view \'' + user.id + '\' page ...');
        };
    }
})();
