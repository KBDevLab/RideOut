// window.leafletInterop = {
//     initializeMap: function (mapId, latitude, longitude, zoomLevel) {
//         var map = L.map(mapId).setView([latitude, longitude], zoomLevel);

//         // Add OpenStreetMap tile layer
//         L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
//             attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
//         }).addTo(map);

//         // Return the map instance (optional)
//         return map;
//     },
//     addMarker: function (latitude, longitude, popupText) {
//         L.marker([latitude, longitude]).addTo(map)
//             .bindPopup(popupText)
//             .openPopup();
//     }
// };