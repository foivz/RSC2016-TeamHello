'use strict';

angular.module('app').controller('homeController', HomeController);

HomeController.$inject = ['loginService'];

function HomeController(loginService) {
    var vm = this;

    vm.number = 3;
};