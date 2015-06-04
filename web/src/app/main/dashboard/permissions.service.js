(function () {
    angular
        .module('spitfire')
        .factory('permissionsService', permissionsService);

    permissionsService.$inject = ['$http'];

    function permissionsService($http) {
        var _getItems = function () {
            $http.defaults.useXDomain = true;
            delete $http.defaults.headers.common['X-Requested-With'];
            return $http.get('https://minierpapi.azurewebsites.net/api/permissions');
        };

        return {
            getItems: _getItems
        };
    }
})();
