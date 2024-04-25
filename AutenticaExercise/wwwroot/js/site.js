let map = L.map('map').setView([56.8801729, 24.6057484], 7);

    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    }).addTo(map);

    function showPoints(areas){
        let locations = JSON.parse(areas);
        
        locations.forEach(function (location) {
            L.marker([location.DD_N, location.DD_E]).bindTooltip(location.Name, {permanent: true}).addTo(map);
        })
        
    }
    
    function selectLocation(){
        let value = document.getElementById('searchText').value
        try {
            var location = JSON.parse(value);
        } catch (e) {
            alert("Ievadīti nekorekti dati");
            return;
        }
        
        L.marker([location.dd_n, location.dd_e]).bindTooltip(location.name, {permanent: true}).addTo(map);
    }