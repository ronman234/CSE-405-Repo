// JavaScript source code

(function () {

    const config = {
        apiKey: "AIzaSyBJ_ereMPOcvOSJPZk4TKR_NFrfnQ49AQk",
        authDomain: "cse-405-project.firebaseapp.com",
        databaseURL: "https://cse-405-project.firebaseio.com",
        projectId: "cse-405-project",
        storageBucket: "cse-405-project.appspot.com",
        messagingSenderId: "938591196493",
        appId: "1:938591196493:web:36ef87dfe6109573ddd304",
        measurementId: "G-J98K3WNZWT"
    };

    if (!firebase.apps.length) {
        firebase.initializeApp(config);
    }

    var defaultData = firebase.database().ref().child('Score');
    if (defaultData)
        console.log("Found it sir")

    var playerScoreArr = [];
    var playerNameArr = [];


    var html = "";
    console.log(playerNameArr.length)
    defaultData.on('value', snap => {
        var scoreQuery = firebase.database().ref().child("Score");
        scoreQuery.orderByKey().once("value")
            .then(function (snapshot) {
                snapshot.forEach(function (childSnapshot) {
                    childSnapshot.forEach(function (innerSnap) {
                        var innerKey = innerSnap.key;
                        var innerValue = innerSnap.val();
                        
                        playerNameArr.push(innerKey);
                        playerScoreArr.push(innerValue);
                    })
                });
            });
       update_score(snap)
    })


    function update_score(snap) {
        console.log(snap.val())
        console.log(playerScoreArr.length)
        for (i = 0; i < playerScoreArr.length - 1; i+=2) {

            html += "<li>" + playerNameArr[i] + " " + playerScoreArr[i] + " : " + playerNameArr[i + 1] + " " + playerScoreArr[i + 1] + "</li>";
            
        }
        playerNameArr.length = 0;
        playerScoreArr.length = 0;
        score_list.innerHTML = html;
        console.log(playerScoreArr.length)
        html = "";
    }

}());