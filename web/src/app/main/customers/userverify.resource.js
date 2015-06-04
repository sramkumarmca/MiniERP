(function () {
    angular
        .module('spitfire')
        .factory('UserVerify', UserVerify);

    UserVerify.$inject = ['$resource'];

    function UserVerify($resource) {
        return $resource('https://minierpapi.azurewebsites.net/api/users/verify/:userName', {
            userName: '@id'
        });
    }
})();
