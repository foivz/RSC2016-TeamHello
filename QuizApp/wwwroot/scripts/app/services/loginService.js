'use strict';

angular.module('app').factory('loginService', LoginService);

LoginService.$inject = ['$q', '$rootScope', '$http', 'userService','$state'];

function LoginService($q, $rootScope, $http, userService, $state) {
    $rootScope.$on('event:social-sign-in-success', function (event, userDetails) {
        loginUser(userDetails);
    });

    $rootScope.$on('event:social-sign-out-success', function (event, logoutStatus) {
        console.log("log out");
    })

    function loginUser(user) {
        $http.post('/api/auth/login', user)
        .then(function (result) {
            userService.setUserId(result.data.id);
            console.log(userService.getUserId());
            console.log(result.data);
            $state.go('home');
        });
    };

    function logoutUser(user) {
        socialLoginService.logout();
    };

    function getCurrentUser(id) {
        return $http.post('/api/auth/getUser/' + id);
    };

    return {
        loginUser: loginUser,
        logoutUser: logoutUser,
        getCurrentUser: getCurrentUser
    };
};