(function () {
    angular
        .module('spitfire')
        .factory('UserVerify', UserVerify);

    UserVerify.$inject = ['$resource'];

    function UserVerify($resource) {
        return $resource('http://firmwarecs.azurewebsites.net/api/users/verify/:userName', {
            userName: '@id'
        });
    }
})();
