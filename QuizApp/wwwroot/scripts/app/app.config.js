angular.module('app').config(AppConfig);

AppConfig.$inject = ['$urlRouterProvider', '$stateProvider', 'socialProvider'];

function AppConfig($urlRouterProvider, $stateProvider, socialProvider) {
    $urlRouterProvider.otherwise('/home');

    socialProvider.setGoogleKey("446715762499-gnm5euquspdh8rvfdfrm53uc2j03l2br.apps.googleusercontent.com");
    socialProvider.setFbKey({ appId: "1805233089714938", apiVersion: "v2.8" });

    //$httpProvider.defaults.common['Authorization'] = loginService.getCurrentToken();
}