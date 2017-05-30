
/// <reference path="../libs/angular/angular.1.2.13.js" />
/// <reference path="../libs/angular/ng-table.js" />

var LoginCtrl;

var app = angular.module("app", ['ui.grid']);

window.identityServer = (function () {
    "use strict";

    var identityServer = 
    {
        getModel: function ()
        {
            var modelJson = document.getElementById("modelJson");
            var encodedJson = '';

            if (typeof (modelJson.textContent) !== undefined)
            {
                encodedJson = modelJson.textContent;
            } else
            {
                encodedJson = modelJson.innerHTML;
            }

            var json = Encoder.htmlDecode(encodedJson);

            var model = JSON.parse(json);

            return model;
        }


    };

    return identityServer;
})();
var LayoutCtrl;


(function () {
    "use strict";
    var LayoutCtrl
    app.controller("LayoutCtrl", ['$scope', '$http', '$filter', 'Model', 'uiGridConstants', function ($scope, $http, $filter, Model, uiGridConstants) {
        LayoutCtrl = $scope;

        LayoutCtrl = $scope;
        $scope.model = Model;
        LoginCtrl = $scope;
          
        //$scope.gridOptions = {
        //    enableSorting: true,
        //    columnDefs: [
        //      { name: 'PESSOA_NOME', enableSorting: false },
        //      { name: 'PESSOA_CPF', visible: true },
        //      { name: 'PESSOA_ATIVO', visible: true }
        //    ],
        //    data: $scope.Users
        //};

        $scope.myData = [{ name: "Moroni", age: 50 },
                    { name: "Tiancum", age: 43 },
                    { name: "Jacob", age: 27 },
                    { name: "Nephi", age: 29 },
                    { name: "Enos", age: 34 }];

        $scope.gridOptions = { data: 'myData' };

        $scope.InsereIdentityUsuario = function () {
            var usuario = $scope.modelUsers;

            var Cadastro = {
                "Username": $("#usuarioForm").val(),
                "Email": $("#emailForm").val(),
                "Superior": $("#superiorForm").val(),
                "Departamento": $("#departamentoForm").val(),
                "Circunscricao": $("#circunscricaoForm").val(),

                "admin": $('input[name="admin"]').bootstrapSwitch('state'),
                "sivic": $('input[name="sivic"]').bootstrapSwitch('state'),
                "area": $('input[name="area"]').bootstrapSwitch('state')
            }


            $http.post("http://localhost:37615/api/Identity/", Cadastro)
           .then(function (response) {

               console.log(response.data);

               var result = response.data;




           });
        };

        $scope.LogarUsuario = function (usuario) {
            //console.log(usuario);
            $http.get("http://localhost:37615/api/Identity/Get?id=" + usuario.ID_PESSOA + "")
           .then(function (response) {
               console.log(response.data);
               var result = response.data;
           });
        };

        $scope.ClearTable = function () {
            $scope.Users = "";
            $scope.$apply();
        };
              

        $scope.GetApi = function () {

            var url_atual = window.location.href;

            $http.get("http://localhost:37615/api/Identity/")
            .then(function (response)
            {

                var result = response.data;

                $scope.gridOptions = { data: result }
                $scope.Users = response.data;               
                $scope.$apply();

            });

        };


        var model = identityServer.getModel();
        angular.module("app").constant("Model", model);
        if (model.autoRedirect && model.redirectUrl) {
            if (model.autoRedirectDelay < 0) {
                model.autoRedirectDelay = 0;
            }
            window.setTimeout(function () {
                window.location = model.redirectUrl;
            }, model.autoRedirectDelay * 1000);
        }
    }]);

    //var LayoutCtrl = function ($scope, $http, $filter, Model) {

    //    LayoutCtrl = $scope;
    //    $scope.model = Model;
    //    LoginCtrl = $scope;

    //    $scope.InsereIdentityUsuario = function () {
    //        var usuario = $scope.modelUsers;

    //        var Cadastro = {
    //            "Username": $("#usuarioForm").val(),
    //            "Email": $("#emailForm").val(),
    //            "Superior": $("#superiorForm").val(),
    //            "Departamento": $("#departamentoForm").val(),
    //            "Circunscricao": $("#circunscricaoForm").val(),

    //            "admin": $('input[name="admin"]').bootstrapSwitch('state'),
    //            "sivic": $('input[name="sivic"]').bootstrapSwitch('state'),
    //            "area": $('input[name="area"]').bootstrapSwitch('state')
    //        }


    //        $http.post("http://localhost:37615/api/Identity/", Cadastro)
    //       .then(function (response) {

    //           console.log(response.data);

    //           var result = response.data;

    //       });
    //    };

    //    $scope.LogarUsuario = function (usuario) {
    //        //console.log(usuario);
    //        $http.get("http://localhost:37615/api/Identity/Get?id=" + usuario.ID_PESSOA + "")
    //       .then(function (response) {
    //           console.log(response.data);
    //           var result = response.data;
    //       });
    //    };

    //    $scope.ClearTable = function () {
    //        $scope.Users = "";
    //        $scope.$apply();
    //    };

    //    $scope.GetApi = function () {

    //        var url_atual = window.location.href;

    //        $http.get("http://localhost:37615/api/Identity/")
    //        .then(function (response) {
    //            var result = response.data;

    //            $scope.Users = response.data;
    //            $scope.myData = response.data;
    //            $scope.$apply();
           
    //        });

    //    };

    //    var model = identityServer.getModel();
    //    angular.module("app").constant("Model", model);
    //    if (model.autoRedirect && model.redirectUrl) {
    //        if (model.autoRedirectDelay < 0) {
    //            model.autoRedirectDelay = 0;
    //        }
    //        window.setTimeout(function () {
    //            window.location = model.redirectUrl;
    //        }, model.autoRedirectDelay * 1000);
    //    }
    //};
    //LayoutCtrl.$inject = ['$scope', '$http', '$filter', 'Model'];

    //var LoginCtrl = function ($scope, $http, $filter, Model) {

    //    LayoutCtrl = $scope;

    //    $scope.model = Model;

    //    LoginCtrl = $scope;

    //    $scope.LogarUsuario = function (usuario) {
    //        //console.log(usuario);
    //        $http.get("http://localhost:37615/api/Identity/Get?id=" + usuario.mem_id + "")
    //       .then(function (response) {
    //           var result = response.data;
    //       });
    //    };

    //    $scope.ClearTable = function () {
    //        $scope.Users = "";
    //        $scope.$apply();
    //    };

    //    $scope.GetApi = function () {

    //        //var Cadastro = {
    //        //    "Nome": $("#usuarioForm").val(),
    //        //    "Email": $("#emailForm").val(),
    //        //    "Superior": $("#superiorForm").val(),
    //        //    "Departamento": $("#departamentoForm").val(),
    //        //    "Circunscricao": $("#circunscricaoForm").val(),

    //        //    "admin": $('input[name="admin"]').bootstrapSwitch('state'),
    //        //    "sivic": $('input[name="sivic"]').bootstrapSwitch('state'),
    //        //    "area": $('input[name="area"]').bootstrapSwitch('state')
    //        //}

    //        $http.get("http://localhost:37615/api/Identity/")
    //        .then(function (response) {
    //            var result = response.data;

    //            $scope.Users = response.data;
    //            $scope.myData = response.data;
    //            $scope.$apply();

    //            //var self = this;                   
    //            //self.tableParams = new NgTableParams({}, { dataset: response });
    //            //$scope.$apply();
    //            //for (var it = 0; it < result.length; it++)
    //            //{
    //            //    $("#table > tbody").append(
    //            //        "<tr>" +
    //            //        "    <th>" + result[it].mem_net_id + "</th>" +
    //            //        "    <th>" + result[it].mem_net_grp + "</th>" +
    //            //        "    <th>" + result[it].mem_tp_membro + "</th>" +
    //            //        "    <th> <input type='checkbox'/></th>" +
    //            //        "</tr>");

    //            //}
    //            //var $table = $('#table');
    //            //$table.bootstrapTable('scrollTo', 0);
    //            //$scope.$apply();
    //        });

    //    };

    //    var model = identityServer.getModel();
    //    angular.module("app").constant("Model", model);
    //    if (model.autoRedirect && model.redirectUrl) {
    //        if (model.autoRedirectDelay < 0) {
    //            model.autoRedirectDelay = 0;
    //        }
    //        window.setTimeout(function () {
    //            window.location = model.redirectUrl;
    //        }, model.autoRedirectDelay * 1000);
    //    }
    //};
    //LoginCtrl.$inject = ['$scope', '$http', '$filter', 'Model'];

    //angular.module("app").controller("LayoutCtrl", LayoutCtrl);
    //angular.module("app").controller("LoginCtrl", LoginCtrl);

    app.directive("antiForgeryToken", function () {
            return {
                restrict: 'E',
                replace: true,
                scope: {
                    token: "="
                },
                template: "<input type='hidden' name='{{token.name}}' value='{{token.value}}'>"
            };
        });

    app.directive("focusIf", function ($timeout) {
            return {
                restrict: 'A',
                scope: {
                    focusIf:'='
                },
                link: function (scope, elem, attrs) {
                    if (scope.focusIf) {
                        $timeout(function () {
                            elem.focus();
                        }, 100);
                    }
                }
            };
        });
 
    var model = identityServer.getModel();
    angular.module("app").constant("Model", model);
    if (model.autoRedirect && model.redirectUrl) {
            if (model.autoRedirectDelay < 0) {
                model.autoRedirectDelay = 0;
            }
            window.setTimeout(function () {
                window.location = model.redirectUrl;
            }, model.autoRedirectDelay * 1000);
        }
    
})();
