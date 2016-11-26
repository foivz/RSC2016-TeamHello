'use strict';

angular.module('app').factory('loginService', LoginService);

LoginService.$inject = ['$q', '$rootScope'];

function LoginService($q, $rootScope) {

    $rootScope.$on('event:social-sign-in-success', function (event, userDetails) {
        console.log(userDetails);

        loginUser(userDetails);
    });

    function loginUser(user) {
        return $http.post('/api/users/login', user);
    };

    return {
        loginUser: loginUser
    };
};