﻿'use strict';

angular.module('app').controller('homeController', HomeController);

HomeController.$inject = [];

function HomeController() {
    var vm = this;

    vm.number = 3;
    
};