//[Dashboard Javascript]




$(function () {

  'use strict';

  // Make the dashboard widgets sortable Using jquery UI
  $('.connectedSortable').sortable({
    placeholder         : 'sort-highlight',
    connectWith         : '.connectedSortable',
    handle              : '.box-header, .nav-tabs',
    forcePlaceholderSize: true,
    zIndex              : 999999
  });
  $('.connectedSortable .box-header, .connectedSortable .nav-tabs-custom').css('cursor', 'move');


	

// chart
	
	$("#linearea").sparkline([1,3,5,4,6,8,7,9,7,8,10,16,14,10], {
			type: 'line',
			width: '100%',
			height: '80',
			lineColor: '#ff6028',
			fillColor: '#ff6028',
			lineWidth: 2,
		});
		
		$("#baralc").sparkline([2,4,3,7,6,4,8,9,6,8,12,6], {
			type: 'bar',
			height: '80',
			barWidth: 10,
			barSpacing: 6,
			barColor: '#ff6028',
		});
		
		$("#lineIncrease").sparkline([1,8,6,5,6,8,7,9,7,8,10,16,14,10], {
			type: 'line',
			width: '100%',
			height: '88',
			lineWidth: 2,
			lineColor: '#ffffff',
			fillColor: "#ff6028",
			spotColor: '#ffffff',
			minSpotColor: '#ffffff',
			maxSpotColor: '#ffffff',
			spotRadius: 3,
		});
	
	
$(':checkbox:checked').prop('checked',false);
var mapData = {
                "US": 298,
                "SA": 200,
                "AU": 760,
                "IN": 200,
                "GB": 120,
            };


jQuery('#world-map-marker').vectorMap(
{
    map: 'world_mill_en',
    backgroundColor: '#fff',
    borderColor: '#fff',
    borderOpacity: 0.25,
    borderWidth: 0,
    color: '#ff6028',
    regionStyle : {
        initial : {
          fill : '#e6e6e6'
        }
      },

    markerStyle: {
      initial: {
                    r: 7,
                    'fill': '#fff',
                    'fill-opacity':1,
                    'stroke': '#000',
                    'stroke-width' : 2,
                    'stroke-opacity': 0.4
                },
                },
   
    markers : [{
        latLng : [21.00, 78.00],
        name : 'INDIA : 350'
      
      },
      {
        latLng : [-33.00, 151.00],
        name : 'Australia : 250'
        
      },
      {
        latLng : [36.77, -119.41],
        name : 'USA : 250'
      
      },
      {
        latLng : [55.37, -3.41],
        name : 'UK   : 250'
      
      },
      {
        latLng : [25.20, 55.27],
        name : 'UAE : 250'
      
      }],
      series: {
                    regions: [{
                        values: mapData,
                        scale: ["#939796", "#838987"],
                        normalizeFunction: 'polynomial'
                    }]
                },
    hoverOpacity: null,
    normalizeFunction: 'linear',
    zoomOnScroll: false,
    scaleColors: ['#b6d6ff', '#005ace'],
    selectedColor: '#c9dfaf',
    selectedRegions: [],
    enableZoom: false,
    hoverColor: '#fff',
    
    
});

 window.addEventListener('resize', function() {
        
    });
	
/*
     * Flot Interactive Chart
     * -----------------------
     */
    // We use an inline data source in the example, usually data would
    // be fetched from a server
    var data = [], totalPoints = 300

    function getRandomData() {

      if (data.length > 0)
        data = data.slice(1)

      // Do a random walk
      while (data.length < totalPoints) {

        var prev = data.length > 0 ? data[data.length - 1] : 50,
            y    = prev + Math.random() * 10 - 5

        if (y < 0) {
          y = 0
        } else if (y > 100) {
          y = 100
        }

        data.push(y)
      }

      // Zip the generated y values with the x values
      var res = []
      for (var i = 0; i < data.length; ++i) {
        res.push([i, data[i]])
      }

      return res
    }

    var interactive_plot = $.plot('#interactive', [getRandomData()], {
      grid: {
            color: "#AFAFAF"
            , hoverable: true
            , borderWidth: 0
            , backgroundColor: '#FFF'
        },
      series: {
        shadowSize: 0, // Drawing is faster without shadows
        color     : '#ff6028'
      },
	  tooltip: true,
      lines : {
        fill : false, //Converts the line chart to area chart
        color: '#ff6028'
      },
	  tooltipOpts: {
            content: "Visit: %y"
            , defaultTheme: false
        },
      yaxis : {
        min : 0,
        max : 100,
        show: true
      },
      xaxis : {
        show: true
      }
    })

    var updateInterval = 10 //Fetch data ever x milliseconds
    var realtime       = 'on' //If == to on then fetch data every x seconds. else stop fetching
    function update() {

      interactive_plot.setData([getRandomData()])

      // Since the axes don't change, we don't need to call plot.setupGrid()
      interactive_plot.draw()
      if (realtime === 'on')
        setTimeout(update, updateInterval)
    }

    //INITIALIZE REALTIME DATA FETCHING
    if (realtime === 'on') {
      update()
    }
    //REALTIME TOGGLE
    $('#realtime .btn').click(function () {
      if ($(this).data('toggle') === 'on') {
        realtime = 'on'
      }
      else {
        realtime = 'off'
      }
      update()
    })
    /*
     * END INTERACTIVE CHART
     */



}); // End of use strict

