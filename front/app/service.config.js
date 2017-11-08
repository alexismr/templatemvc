(function () {
    'use strict';
    angular.module('services.config', [])
        .constant('appConfig', AppConfig());
    function AppConfig() {
        return {
            apiServiceBaseUri: 'http://localhost:9992/api/',
            user : "alexis mr"
        }
    }
})();