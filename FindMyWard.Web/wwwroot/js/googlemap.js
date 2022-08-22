const url = window.location.pathname;


function initMap() { 
    const myLatlng = { lat:6.6726 , lng: 3.1573813 };
    const map = new google.maps.Map(document.getElementById("map"), {
    zoom: 17,
    center: myLatlng,
    });

    var lat = document.getElementById("loc.lat").value;
    var lng = document.getElementById("loc.long").value;
    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(lat,lng),
        map: map,
    });

    if(lat && lng)
        map.center = marker.position;

    if (!url.includes('Detail') || !url.includes('detail')) {
        map.addListener("click", (mapsmouseEvent) => {
            document.getElementById("loc.lat").value = mapsmouseEvent.latLng.lat();
            document.getElementById("loc.long").value = mapsmouseEvent.latLng.lng();
            document.getElementById("loc.zoom").value = map.getZoom();
            if (marker) {
                marker.setMap(null);
            }
            marker = new google.maps.Marker({
                position : mapsmouseEvent.latLng,
                map : map,
            })
        });
    }
}

window.initMap = initMap;
