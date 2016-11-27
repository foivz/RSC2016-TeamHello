'use strict';

angular.module('app').factory('loginService', LoginService);

LoginService.$inject = ['$q', '$rootScope', '$http'];

function LoginService($q, $rootScope, $http) {
    var user;

    $rootScope.$on('event:social-sign-in-success', function (event, userDetails) {
        user = userDetails;

        loginUser(userDetails);
    });

    $rootScope.$on('event:social-sign-out-success', function (event, logoutStatus) {
        console.log("log out");

        user = null;
    })

    function loginUser(user) {
        return $http.post('/api/auth/login', user);
    };

    function logoutUser(user) {
        socialLoginService.logout();
    };

    function getCurrentUser() {
        return user;
    };

    function getCurrentToken() {
        return user;
    };

    return {
        loginUser: loginUser,
        logoutUser: logoutUser,
        getCurrentUser: getCurrentUser,
        getCurrentToken: getCurrentToken
    };
};