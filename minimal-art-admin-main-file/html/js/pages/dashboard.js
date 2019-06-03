//[Dashboard Javascript]



$(function () {

  'use strict';


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



  /* jVector Maps
   * ------------
   * Create a world map with markers
   */
	
	jQuery('#visitfromworld').vectorMap({
        map: 'world_mill_en',
        backgroundColor: '#fff',
        borderColor: '#000',
        borderOpacity: 1,
        borderWidth: 1,
        zoomOnScroll : false,
        color: '#ddd',
        regionStyle: {
            initial: {
                fill: '#ccc',
            }
        },
        markerStyle: {
            initial: {
                r: 8,
                 'fill': '#ff6028',
                 'fill-opacity': 1,
                 'stroke': '#000',
                 'stroke-width': 0,
                 'stroke-opacity': 1,
            }
         },
         enableZoom: true,
         hoverColor: '#ff6028',
         markers: [{
            latLng: [21.00, 78.00],
            name: 'India : 9347',
            style: {fill: '#ff6028'}
        },
      {
        latLng : [-33.00, 151.00],
        name : 'Australia : 250',
        style: {fill: '#ff6028'}
      },
      {
        latLng : [36.77, -119.41],
        name : 'USA : 250',
        style: {fill: '#ff6028'}
      },
      {
        latLng : [55.37, -3.41],
        name : 'UK   : 250',
         style: {fill: '#ff6028'}
      },
      {
        latLng : [25.20, 55.27],
        name : 'UAE : 250',
        style: {fill: '#ff6028'}
      }],
         hoverOpacity: null,
         normalizeFunction: 'linear',
         scaleColors: ['#fff', '#ccc'],
         selectedColor: '#c9dfaf',
         selectedRegions: [],
         showTooltip: true,
         onRegionClick: function (element, code, region) {
            var message = 'You clicked "' + region + '" which has the code: ' + code.toUpperCase();
            alert(message);
        }
    });


// -----------------
  // - SPARKLINE BAR -
  // -----------------
  $('.sparkbar').each(function () {
    var $this = $(this);
    $this.sparkline('html', {
      type    : 'bar',
      height  : $this.data('height') ? $this.data('height') : '30',
      barColor: $this.data('color')
    });
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
		barColors: ['#ff6028', '#f9784a', '#fb8a61'],
		barSizeRatio: 0.5,
		barGap:1,
		xkey: 'y',
		ykeys: ['a', 'b', 'c'],
		labels: ['Morning', 'Evening', 'Night'],
		hideHover: 'auto'
    });	
	
   //-------------
		//- BAR CHART -
		//-------------
		
		// Get context with jQuery - using jQuery's .get() method.
		var barChartCanvas = $('#barChart').get(0).getContext('2d');
		// This will get the first returned node in the jQuery collection.
		var barChart            = new Chart(barChartCanvas);

		var barChartData = {
		  labels  : ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
		  datasets: [
			{
			  label               : 'Electronics',
			  fillColor           : '#ff6028',
			  strokeColor         : 'rgba(38,198,218,0)',
			  pointColor          : '#26c6da',
			  pointStrokeColor    : 'rgba(38,198,218,0)',
			  pointHighlightFill  : '#fff',
			  pointHighlightStroke: '#ff6028',
			  data                : [5, 4, 3, 7, 5, 10, 3]
			},
			{
			  label               : 'Digital Goods',
			  fillColor           : '#f9784a',
			  strokeColor         : 'rgba(30,136,229,0)',
			  pointColor          : 'rgba(30,136,229,0)',
			  pointStrokeColor    : '#1e88e5',
			  pointHighlightFill  : '#fff',
			  pointHighlightStroke: '#f9784a',
			  data                : [3, 2, 9, 5, 4, 6, 4]
			}
		  ]
		};
		
		
		var barChartOptions                  = {
		  //Boolean - Whether the scale should start at zero, or an order of magnitude down from the lowest value
		  scaleBeginAtZero        : true,
		  //Boolean - Whether grid lines are shown across the chart
		  scaleShowGridLines      : true,
		  //String - Colour of the grid lines
		  scaleGridLineColor      : 'rgba(0,0,0,.05)',
		  //Number - Width of the grid lines
		  scaleGridLineWidth      : 1,
		  //Boolean - Whether to show horizontal lines (except X axis)
		  scaleShowHorizontalLines: true,
		  //Boolean - Whether to show vertical lines (except Y axis)
		  scaleShowVerticalLines  : true,
		  //Boolean - If there is a stroke on each bar
		  barShowStroke           : true,
		  //Number - Pixel width of the bar stroke
		  barStrokeWidth          : 2,
		  //Number - Spacing between each of the X value sets
		  barValueSpacing         : 30,
		  //Number - Spacing between data sets within X values
		  barDatasetSpacing       : 1,
		  //String - A legend template
		  legendTemplate          : '<ul class="<%=name.toLowerCase()%>-legend"><% for (var i=0; i<datasets.length; i++){%><li><span style="background-color:<%=datasets[i].fillColor%>"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>',
		  //Boolean - whether to make the chart responsive
		  responsive              : true,
		  maintainAspectRatio     : true
		};

		barChartOptions.datasetFill = false,
		barChart.Bar(barChartData, barChartOptions);
	


}); // End of use strict
