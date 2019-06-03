//[widget morris charts Javascript]



$(function () {
    "use strict";

    // AREA CHART
    var area = new Morris.Area({
      element: 'revenue-chart',
      resize: true,
      data: [
        { y: '2017-01', a: 1, b: 2 },
		{ y: '2017-02', a: 2,  b: 3 },
		{ y: '2017-03', a: 2,  b: 2 },
		{ y: '2017-04', a: 1,  b: 4 },
		{ y: '2017-05', a: 2,  b: 5 },
		{ y: '2017-06', a: 3,  b: 3 },
		{ y: '2017-07', a: 1, b: 2 }
      ],
		xkey: 'y',
		ykeys: ['a', 'b'],
		labels: ['Individual Score', 'Team Score'],
		fillOpacity: 0.2,
		lineWidth:1,
		lineColors: ['#ff6028', '#f96c3b'],
		hideHover: 'auto'
    });

    // LINE CHART
    var line = new Morris.Line({
      element: 'line-chart',
      resize: true,
      data: [
        {y: '2007', item1: 1234},
        {y: '2008', item1: 2345},
        {y: '2009', item1: 4896},
        {y: '2010', item1: 8954},
        {y: '2011', item1: 5698},
        {y: '2012', item1: 6987},
        {y: '2013', item1: 7896},
        {y: '2014', item1: 19001},
        {y: '2015', item1: 9632},
        {y: '2016', item1: 18001}
      ],
		xkey: 'y',
		ykeys: ['item1'],
		labels: ['Analatics'],
		lineWidth:2,
		pointFillColors: ['#ff6028'],
		lineColors: ['#ff6028'],
		hideHover: 'auto',
    });

    //DONUT CHART
    var donut = new Morris.Donut({
      element: 'sales-chart',
      resize: true,
      colors: ["#fb784b", "#f96c3b", "#ff6028"],
      data: [
        {label: "Download Sales", value: 30},
        {label: "In-Store Sales", value: 45},
        {label: "Mail-Order Sales", value: 25}
      ],
      hideHover: 'auto'
    });
    //BAR CHART
    var bar = new Morris.Bar({
      element: 'bar-chart',
      resize: true,
      data: [
        {y: 'Mon', a: 5, b: 3, c: 3},
        {y: 'Tue', a: 4, b: 2, c: 7},
        {y: 'Wed', a: 3, b: 9, c: 4},
        {y: 'Thu', a: 7, b: 5, c: 3},
        {y: 'Fri', a: 5, b: 4, c: 9},
        {y: 'Sat', a: 10, b: 6, c: 3},
		{y: 'Sun', a: 8, b: 9, c: 4}
      ],
		barColors: ['#ff6028', '#f96c3b', '#fb784b'],
		barSizeRatio: 0.5,
		barGap:2,
		xkey: 'y',
		ykeys: ['a', 'b', 'c'],
		labels: ['Morning', 'Evening', 'Night'],
		hideHover: 'auto'
    });
  });