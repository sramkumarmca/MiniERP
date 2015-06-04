'use strict';

(function () {
    angular
        .module('spitfire')
        .controller('MainDashboardController', MainDashboardController);

    MainDashboardController.$inject = ['permissionsService'];

    function MainDashboardController(permissionsService) {
        permissionsService.getItems().success(function (results) {
            console.log('Permissions: ' + JSON.stringify(results));
        }).error(function (err) {
            console.log('Error: ' + err);
        });
    }
})();
