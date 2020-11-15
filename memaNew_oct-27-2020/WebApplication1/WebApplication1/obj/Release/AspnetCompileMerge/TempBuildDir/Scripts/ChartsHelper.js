var chartHelper = {

    barChart: function (data, id, argumentField, valueField,name) {

        $(id).dxChart({
            dataSource: data,
            series: {
                argumentField: argumentField,
                valueField: valueField,
                name: name,
                type: "bar",
                color: '#ffaa66'
            }
        });

    },
    PieChart: function (data, id, argumentField, valueField, title) {

            $(id).dxPieChart({
                size: {
                    width: 500
                },
                palette: "bright",
                dataSource: data,
                series: [
                    {
                        argumentField: argumentField,
                        valueField: valueField,
                        label: {
                            visible: true,
                            connector: {
                                visible: true,
                                width: 1
                            }
                        }
                    }
                ],
                title: title,
                "export": {
                    enabled: false
                },
                onPointClick: function (e) {
                    var point = e.target;

                    toggleVisibility(point);
                },
                onLegendClick: function (e) {
                    var arg = e.target;

                    toggleVisibility(this.getAllSeries()[0].getPointsByArg(arg)[0]);
                }
            });

            function toggleVisibility(item) {
                if (item.isVisible()) {
                    item.hide();
                } else {
                    item.show();
                }
            }
        



    }





}