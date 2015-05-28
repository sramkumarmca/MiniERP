(function () {
    angular
        .module('spitfire')
        .factory('UserVerify', UserVerify);

    UserVerify.$inject = ['$resource'];

    function UserVerify($resource) {
        return $resource('http://localhost:1996/api/users/verify/:userName', {
            userName: '@id'
        });
    }
})();
