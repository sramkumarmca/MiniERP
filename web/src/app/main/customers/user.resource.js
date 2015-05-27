(function () {
    angular
        .module('spitfire')
        .factory('User', User);

    User.$inject = ['$resource'];

    function User($resource) {
        return $resource('http://localhost:1996/api/users');
    }
})();
