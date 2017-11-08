(function () {
    'use strict';

    angular.module('pruebaAlexis', [
        'ui.router',
         // Form Modules
        'Empleado.module',
        // API Service Context
        'services.config'
    ])
    .config(['$stateProvider', '$urlRouterProvider',
            function ($stateProvider, $urlRouterProvider) {
                $stateProvider
                    .state('Empleados', {
                        url: '/Empleados',
                        templateUrl: '/app/Empleados/Empleados.html',
                        controller: 'empleadocontroller as Empleadovm'
                    });
                  $urlRouterProvider.otherwise('Empleados');
       }]);
})()










       



