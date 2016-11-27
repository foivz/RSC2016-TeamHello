'use strict';

angular.module('app').controller('loginController', LoginController);

LoginController.$inject = ['$state', 'teamService', 'userService', 'loginService'];

function LoginController($state, teamService, userService, loginService) {
    var vm = this;

};