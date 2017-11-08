(function () {
    'use strict';
    angular.module('Empleado.service', [])
    .factory('EmpleadoService', ServiceEmpleado);
    ServiceEmpleado.$inject = ['$http', '$q','appConfig'];

    function ServiceEmpleado($http, $q, appConfig) {
            var UrlBase = appConfig.apiServiceBaseUri;
            function _GetEmpledos() {
                 return $q(function (resolve, reject) {
                   $http.get(UrlBase +"Empleado")
                     .success(function (respons) {
                         resolve(respons);
                      })
                      .error(function (mensaje) {
                          reject(mensaje);
                     });
                 });


                 //var deferred = $q.defer();

                 //$http.get(UrlBase +"Empleado")
                 // .success(function (dataJson) {

                 //   })
                 // .error(function (mensaje) {
                 //    console.log(mensaje);
                 //  });
                 //return deferred.promise;

             }

            

            function _DeleteEmpledos(id) {
                return $q(function (resolve, reject) {
                    $http.delete(UrlBase + "Empleado/DeleteEmpleado/" + id)
                        .success(function (respons) {
                            resolve(respons);
                        })
                        .error(function (mensaje) {
                            reject(mensaje);
                        });
                });
            }

            function _SaveEmpledo(empleado) {
                return $q(function (resolve, reject) {
                    $http.post(UrlBase + "Empleado/addEmpleado", empleado)
                        .success(function (respons) {
                            resolve(respons);
                        })
                        .error(function (mensaje) {
                            reject(mensaje);
                        });
                });
            }


             return {
                 GetEmpledos: _GetEmpledos,
                 DeleteEmpledos: _DeleteEmpledos,
                 SaveEmpledo:  _SaveEmpledo
             }
         }

       

})();