var app = angular.module('app', ['ngAnimate', 'ngTouch', 'ui.grid', 'ui.grid.autoResize']);

app.controller('MainCtrl', ['$scope', '$http', 'uiGridConstants', function ($scope, $http, uiGridConstants) {
  var today = new Date();
  var nextWeek = new Date();
  nextWeek.setDate(nextWeek.getDate() + 7);

  $scope.highlightFilteredHeader = function( row, rowRenderIndex, col, colRenderIndex ) {
    if( col.filters[0].term ){
      return 'header-filtered';
    } else {
      return '';
    }
  };

  $scope.gridOptions = {
    enableFiltering: true,
    onRegisterApi: function(gridApi){
      $scope.gridApi = gridApi;
    },
    columnDefs:  [
              { name: 'id', enableCellEdit: false, width: '100' },
              { name: 'name', displayName: 'Name (editable)', width: '200' },
              { name: 'age', displayName: 'Age', type: 'number', width: '100' }


            ]
  };

    $scope.gridOptions.data = [
                { id: 1, name: "Anderson", age: 12 },
                { id: 2, name: "Zdzislaw", age: 12 }
            ];

            //$http.get('/data/500_complex.json')
            //  .success(function (data) {
            //      for (i = 0; i < data.length; i++) {
            //          data[i].registered = new Date(data[i].registered);
            //          data[i].gender = data[i].gender === 'male' ? 1 : 2;
            //          if (i % 2) {
            //              data[i].pet = 'fish'
            //              data[i].foo = { bar: [{ baz: 2, options: [{ value: 'fish' }, { value: 'hamster' }] }] }
            //          }
            //          else {
            //              data[i].pet = 'dog'
            //              data[i].foo = { bar: [{ baz: 2, options: [{ value: 'dog' }, { value: 'cat' }] }] }
            //          }
            //      }
            //      $scope.gridOptions.data = data;
            //  });

  $scope.toggleFiltering = function(){
    $scope.gridOptions.enableFiltering = !$scope.gridOptions.enableFiltering;
    $scope.gridApi.core.notifyDataChange( uiGridConstants.dataChange.COLUMN );
  };
}])
.filter('mapGender', function() {
  var genderHash = {
    1: 'male',
    2: 'female'
  };

  return function(input) {
    if (!input){
      return '';
    } else {
      return genderHash[input];
    }
  };
});
