'use strict';

angular.module('app').factory('loginService', LoginService);

LoginService.$inject = ['$q', '$rootScope'];

function LoginService($q, $rootScope) {
    var user;
    var token;

    $rootScope.$on('event:social-sign-in-success', function (event, userDetails) {
        console.log(userDetails);
        user = userDetails;

        loginUser(userDetails);
    });

    $rootScope.$on('event:social-sign-out-success', function (event, logoutStatus) {
        console.log("log out");

        user = null;
        token = null;
    })

    function loginUser(user) {
        $http.post('/api/users/login', user)
        .then(function (result) {
            token = result.data;

            return token;
        });
    };

    function logoutUser(user) {
        socialLoginService.logout();
    };

    function getCurrentUser() {
        return user;
    };

    return {
        loginUser: loginUser
    };
};