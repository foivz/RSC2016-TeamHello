﻿angular.module('app').factory('userService', UserService);

function UserService() {
    var UserId;
    return {
        getUserId: function () { return UserId; },
        setUserId: function (userId) { UserId = userId;}
    }
}