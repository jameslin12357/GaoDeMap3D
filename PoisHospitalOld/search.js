var button = document.getElementById('done');
var coordsContainer = document.getElementById(('coordsContainer'));
button.addEventListener('click',function(e){
    console.log(`[${coordsContainer.innerText.slice(0,coordsContainer.innerText.length - 1)}]`);
    console.log(`"poiBounds":"[${coordsContainer.innerText.slice(0,coordsContainer.innerText.length - 1)}]",`);
    var coords = JSON.parse(`[${coordsContainer.innerText.slice(0,coordsContainer.innerText.length - 1)}]`);
    console.log(typeof coords);
    var path = [];
    coords.forEach(function(coord) {
        path.push(new AMap.LngLat(coord[0], coord[1]))
    });
    var polygon = new AMap.Polygon({
        path: path,
        fillColor: '#fff', // 多边形填充颜色
        borderWeight: 2, // 线条宽度，默认为 1
        strokeColor: 'red', // 线条颜色
    });
    var map;

    map.add(polygon);
});