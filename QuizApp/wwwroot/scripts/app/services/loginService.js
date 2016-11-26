'use strict';

angular.module('app').factory('loginService', LoginService);

LoginService.$inject = ['$q', '$rootScope'];

function LoginService($q, $rootScope) {
    var user;

    $rootScope.$on('event:social-sign-in-success', function (event, userDetails) {
        console.log(userDetails);
        user = userDetails;

        loginUser(userDetails);
    });

    $rootScope.$on('event:social-sign-out-success', function (event, logoutStatus) {
        console.log("log out");

        user = null;
    })

    function loginUser(user) {
        return $http.post('/api/users/login', user);
    };

    function logoutUser(user) {
        socialLoginService.logout();
    };

    function getCurrentUser(user) {
        return user;
    };

    return {
        loginUser: loginUser
    };
};