(function () {
    angular
        .module('spitfire')
        .factory('User', User);

    User.$inject = ['$resource'];

    function User($resource) {
        return $resource('https://minierpapi.azurewebsites.net/api/users/:id', {
            id: '@id'
        }, {
            'update': {
                method: 'PUT'
            }
        });
    }
})();
