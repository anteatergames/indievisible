//[widget charts Javascript]




$(function () {

  'use strict';

  $(function () {
		/* ChartJS
		 * -------
		 * Here we will create a few charts using ChartJS
		 */

		//--------------
		//- AREA CHART -
		//--------------

		// Get context with jQuery - using jQuery's .get() method.
		var areaChartCanvas = $('#areaChart').get(0).getContext('2d')
		// This will get the first returned node in the jQuery collection.
		var areaChart       = new Chart(areaChartCanvas)

		var areaChartData = {
		  labels  : ['0', '4', '8', '12', '16', '20', '24', '30', '16', '20', '24', '30', '34', '38', '42', '46', '50', '54'],
		  datasets: [
			{
			  label               : 'Electronics',
			  fillColor           : '#ff6028',
			  strokeColor         : 'rgba(30,172,190,0)',
			  pointColor          : '#ff6028',
			  pointStrokeColor    : '#ff6028',
			  pointHighlightFill  : '#fff',
			  pointHighlightStroke: '#ff6028',
			  data                : [14, 4, 6, 17, 5, 10, 14, 15, 14, 17, 29, 26, 30, 16, 37, 31, 44, 52]
			},
			{
			  label               : 'Digital Goods',
			  fillColor           : '#ff60289c',
			  strokeColor         : 'rgba(38,198,218,0)',
			  pointColor          : '#ff6028',
			  pointStrokeColor    : '#ff6028',
			  pointHighlightFill  : '#fff',
			  pointHighlightStroke: '#ff6028',
			  data                : [8, 3, 4, 14, 13, 5, 17, 24, 24, 45, 27, 20, 28, 13, 34, 48, 31, 50]
			}
		  ]
		}

		var areaChartOptions = {
		  //Boolean - If we should show the scale at all
		  showScale               : true,
		  //Boolean - Whether grid lines are shown across the chart
		  scaleShowGridLines      : false,
		  //String - Colour of the grid lines
		  scaleGridLineColor      : 'rgba(0,0,0,.05)',
		  //Number - Width of the grid lines
		  scaleGridLineWidth      : 1,
		  //Boolean - Whether to show horizontal lines (except X axis)
		  scaleShowHorizontalLines: true,
		  //Boolean - Whether to show vertical lines (except Y axis)
		  scaleShowVerticalLines  : true,
		  //Boolean - Whether the line is curved between points
		  bezierCurve             : true,
		  //Number - Tension of the bezier curve between points
		  bezierCurveTension      : 0.5,
		  //Boolean - Whether to show a dot for each point
		  pointDot                : true,
		  //Number - Radius of each point dot in pixels
		  pointDotRadius          : 1,
		  //Number - Pixel width of point dot stroke
		  pointDotStrokeWidth     : 1,
		  //Number - amount extra to add to the radius to cater for hit detection outside the drawn point
		  pointHitDetectionRadius : 20,
		  //Boolean - Whether to show a stroke for datasets
		  datasetStroke           : true,
		  //Number - Pixel width of dataset stroke
		  datasetStrokeWidth      : 0,
		  //Boolean - Whether to fill the dataset with a color
		  datasetFill             : true,
		  //String - A legend template
		  legendTemplate          : '<ul class="<%=name.toLowerCase()%>-legend"><% for (var i=0; i<datasets.length; i++){%><li><span style="background-color:<%=datasets[i].lineColor%>"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>',
		  //Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
		  maintainAspectRatio     : true,
		  //Boolean - whether to make the chart responsive to window resizing
		  responsive              : true
		};
		
		//Create the line chart
		areaChart.Line(areaChartData, areaChartOptions);
		
		//----------------------------line
		
		// Get context with jQuery - using jQuery's .get() method.
		var lineChartCanvas = $('#lineChart').get(0).getContext('2d');
		// This will get the first returned node in the jQuery collection.
		var lineChart                = new Chart(lineChartCanvas);

		var lineChartData = {
		  labels  : ['0', '4', '8', '12', '16', '20', '24', '30'],
		  datasets: [
			{
			  label               : 'Electronics',
			  fillColor           : 'rgba(38,198,218,0)',
			  strokeColor         : '#ff6028',
			  pointColor          : '#ff6028',
			  pointStrokeColor    : '#ff6028',
			  pointHighlightFill  : '#fff',
			  pointHighlightStroke: '#ff6028',
			  data                : [0, 2, 3.5, 0, 13, 1, 4, 1]
			},
			{
			  label               : 'Digital Goods',
			  fillColor           : 'rgba(30,136,229,0)',
			  strokeColor         : '#ff6028',
			  pointColor          : '#ff6028',
			  pointStrokeColor    : '#ff6028',
			  pointHighlightFill  : '#fff',
			  pointHighlightStroke: '#ff6028',
			  data                : [0, 4, 0, 4, 0, 4, 0, 4]
			}
		  ]
		};

		var lineChartOptions = {
		  //Boolean - If we should show the scale at all
		  showScale               : true,
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
		  //Boolean - Whether the line is curved between points
		  bezierCurve             : true,
		  //Number - Tension of the bezier curve between points
		  bezierCurveTension      : 0.3,
		  //Boolean - Whether to show a dot for each point
		  pointDot                : true,
		  //Number - Radius of each point dot in pixels
		  pointDotRadius          : 1,
		  //Number - Pixel width of point dot stroke
		  pointDotStrokeWidth     : 1,
		  //Number - amount extra to add to the radius to cater for hit detection outside the drawn point
		  pointHitDetectionRadius : 20,
		  //Boolean - Whether to show a stroke for datasets
		  datasetStroke           : true,
		  //Number - Pixel width of dataset stroke
		  datasetStrokeWidth      : 1,
		  //Boolean - Whether to fill the dataset with a color
		  datasetFill             : true,
		  //String - A legend template
		  legendTemplate          : '<ul class="<%=name.toLowerCase()%>-legend"><% for (var i=0; i<datasets.length; i++){%><li><span style="background-color:<%=datasets[i].lineColor%>"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>',
		  //Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
		  maintainAspectRatio     : true,
		  //Boolean - whether to make the chart responsive to window resizing
		  responsive              : true
		};
		
		//Create the line chart
		lineChart.Line(lineChartData, lineChartOptions);
		
		

		//-------------
		//- PIE CHART -
		//-------------
		// Get context with jQuery - using jQuery's .get() method.
		var pieChartCanvas = $('#pieChart').get(0).getContext('2d');
		var pieChart       = new Chart(pieChartCanvas);
		var PieData        = [
		  {
			value    : 750,
			color    : '#ff6028',
			highlight: '#ff6028',
			label    : 'Chrome'
		  },
		  {
			value    : 350,
			color    : '#f96c3b',
			highlight: '#f96c3b',
			label    : 'IE'
		  },
		  {
			value    : 450,
			color    : '#fb784b',
			highlight: '#fb784b',
			label    : 'FireFox'
		  },
		  {
			value    : 700,
			color    : '#f98158',
			highlight: '#f98158',
			label    : 'Safari'
		  },
		  {
			value    : 200,
			color    : '#fb936f',
			highlight: '#fb936f',
			label    : 'Opera'
		  },
		  {
			value    : 150,
			color    : '#f9a284',
			highlight: '#f9a284',
			label    : 'Navigator'
		  }
		];
		var pieOptions     = {
		  //Boolean - Whether we should show a stroke on each segment
		  segmentShowStroke    : true,
		  //String - The colour of each segment stroke
		  segmentStrokeColor   : '#fff',
		  //Number - The width of each segment stroke
		  segmentStrokeWidth   : 2,
		  //Number - The percentage of the chart that we cut out of the middle
		  percentageInnerCutout: 80, // This is 0 for Pie charts
		  //Number - Amount of animation steps
		  animationSteps       : 100,
		  //String - Animation easing effect
		  animationEasing      : 'easeOutBounce',
		  //Boolean - Whether we animate the rotation of the Doughnut
		  animateRotate        : true,
		  //Boolean - Whether we animate scaling the Doughnut from the centre
		  animateScale         : true,
		  //Boolean - whether to make the chart responsive to window resizing
		  responsive           : true,
		  // Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
		  maintainAspectRatio  : true,
		  //String - A legend template
		  legendTemplate       : '<ul class="<%=name.toLowerCase()%>-legend"><% for (var i=0; i<segments.length; i++){%><li><span style="background-color:<%=segments[i].fillColor%>"></span><%if(segments[i].label){%><%=segments[i].label%><%}%></li><%}%></ul>'
		};
		//Create pie or douhnut chart
		// You can switch between pie and douhnut using the method below.
		pieChart.Doughnut(PieData, pieOptions);

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
			  pointColor          : '#ff6028',
			  pointStrokeColor    : 'rgba(38,198,218,0)',
			  pointHighlightFill  : '#fff',
			  pointHighlightStroke: '#ff6028',
			  data                : [5, 4, 3, 7, 5, 10, 3]
			},
			{
			  label               : 'Digital Goods',
			  fillColor           : '#fb784b',
			  strokeColor         : 'rgba(30,136,229,0)',
			  pointColor          : 'rgba(30,136,229,0)',
			  pointStrokeColor    : '#fb784b',
			  pointHighlightFill  : '#fff',
			  pointHighlightStroke: '#fb784b',
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
	  });
}); // End of use strict
