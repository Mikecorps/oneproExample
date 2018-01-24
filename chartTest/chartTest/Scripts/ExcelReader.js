var module = angular.module('excelApp', []);
module.directive('fileread', function ($rootScope) {
    return {
        scope: {
            fileread: '='
        },
        link: function (scope, element, attrubutes) {
            element.bind("change", function (changeEvent) {
                var reader = new FileReader();
                reader.onload = function (loadEvent) {
                    scope.$apply(function () {
                        var fileread = loadEvent.target.result;
                        var extentionXlsx = /(.xlsx)$/;
                        var extentionXls = /(.xls)$/;
                        var workbook = XLSX.read(fileread, { type: 'binary' });
                        scope.fileread = [];
                        var cont = 0;
                        workbook.SheetNames.forEach(function (key) {
                            scope.fileread[cont] = XLSX.utils.sheet_to_json(workbook.Sheets[key]);
                            cont++;
                        });
                        $rootScope.$emit('ExcelData', scope.fileread);
                        
                    });
                }
                reader.readAsBinaryString(changeEvent.target.files[0]);
            });
        }
    }
});
module.controller('DataSet', function ($scope, $rootScope) {
    $scope.RadioType;
    $scope.data = [];
    $scope.xAxis = [];
    $scope.variable;
    $scope.TracesData = [];
    $scope.types = [
        {
            name: "Lineas",
            value: "lines+markers"
        },
        {
            name: "Scatter",
            value: "markers"
        },
          {
            name: "Area",
            value: "lines+markers"
        }

    ];
   
    
    var div = document.getElementById('table');
    $rootScope.$on('ExcelData', function (event, data) {
        $scope.columns = [];
        $scope.data = data[0];
        angular.forEach(data[0][0], function (value, key) {
            this.push(key)
        }, $scope.columns);
        $scope.config = {
            data: data[0], 
            colHeaders: $scope.columns,
            stretchH: 'all',
            autoWrapRow: true,
            minSpareRows: true,
            columnSorting: true,
            autoWrapRow: true,
            height: 250,
            rowHeaders: true,
        }
        var table = new Handsontable(div, $scope.config);
        
        
    });
    $scope.addTrace = function () {
        $scope.TracesData.push({
            variable: $scope.variable,
            tipo: '',
            ejeY: '',
            ejeX:'',
            size:'',
            color: '',
            fill:''
        });
        
    }
    $scope.deleteTrace = function (btn)
    {
        var index = $scope.TracesData.indexOf(btn);
        $scope.TracesData.splice(index, 1);
        
    }
    
    $scope.plottSerie = function () {
        
        var y = 'yaxis';
        angular.forEach($scope.TracesData, function (val, key) { 
            var yAx = [];
            angular.forEach($scope.data, function (value, key2) {
                yAx.push(value[val.variable]);
                if ($scope.xAxis.indexOf(key2) === -1) {
                    $scope.xAxis.push(key2);
                }
            });
           
            var trace = {
                x: $scope.xAxis,
                y: yAx,
                name: val.variable,
                type: 'scatter',
                mode: val.tipo,
                marker: {
                    color: val.color,
                    size: val.size,
                    opacity:0.7
                }
            }
            if ($scope.axis > 1)
            {
                var newYaxis =
                {
                    tickfont: { color: val.color },
                    overlaying: 'y1',
                    position: $scope.pading,
                    vrangemode: "tozero",
                    autorange: true
                };
                trace["yaxis"] = 'y' + $scope.axis;
                $scope.layout[y + $scope.axis] = newYaxis;
                $scope.pading += 0.05;
            }
            $scope.layout.xaxis["range"] = [-Math.round($scope.xAxis[$scope.xAxis.length - 1] * 0.20), $scope.xAxis[$scope.xAxis.length - 1]];
            $scope.traces.push(trace);
            $scope.axis += 1
        });
        Plotly.newPlot('myDiv', $scope.traces, $scope.layout, {
            modeBarButtonsToRemove: ['sendDataToCloud', 'lasso2d', 'hoverCompareCartesian'],
            displaylogo: false
        });
        
    }
    $scope.plottXY = function () {
        var yAx;
        var xAx;
    }
    $scope.plott = function ()
    {
        $scope.pading = 0.05;
        $scope.traces = [];
        $scope.axis = 1;
        $scope.layout = {
            autosize: true,
            legend: { "orientation": "h" },
            xaxis: {
                showgrid: true,
                showline: true,
                mirror: "ticks",
                gridcolor: "#bdbdbd",
                linecolor: "#636363",
                linewidth: 6,
               

            },
            yaxis: {
                showgrid: true,
                showline: true,
                mirror: "ticks",
                gridcolor: "#bdbdbd",
                linecolor: "#636363",
                linewidth: 6,   
            },
            

        }
        if ($scope.RadioType == "1")
            $scope.plottSerie();
        else if ($scope.RadioType == "2")
        {
        }
    }
   


    
    



});