(function () {
    'use strict';
    angular.module('Empleado.module')
    .controller('empleadocontroller', Empleadocontroller);
    // inject dependenc
    Empleadocontroller.$inject = ['$location','EmpleadoService'];
    function Empleadocontroller($location, EmpleadoService) {

        var Empleadovm = this;
        // list declaration 
        Empleadovm.Personas = [];
        // obj
        Empleadovm.person = {};
        Empleadovm.nuevo = false;


        function loadClientes() {
            EmpleadoService.GetEmpledos().then(function (result) {
                Empleadovm.Personas = result;
            }, function (reason) {
                alert('Failed: ' + reason);
            })
        }


        Empleadovm.init = function ()
        {
            loadClientes();
        }

        Empleadovm.onDelete = function() {
            EmpleadoService.DeleteEmpledos(Empleadovm.idDelete).then(function (result) { 
                if (result) 
                    loadClientes();

                
               $('#deleteModal').modal('hide');

            }, function (reason) {
                  $('#deleteModal').modal('hide');
                alert('Failed: ' + reason);
            })
            
        }

        Empleadovm.savePerson = function () {

            console.log("entro Save", Empleadovm.person);
            EmpleadoService.SaveEmpledo(Empleadovm.person).then(function (result) {
                if (result) {
                    loadClientes();
                    Empleadovm.nuevo = false;
                    Empleadovm.person = {};
                }
       
            }, function (reason) {
                alert('Failed: ' + reason);
            })
        }


        Empleadovm.init();
       
        
    }


})();