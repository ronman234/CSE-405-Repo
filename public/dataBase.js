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

    var defaultData = firebase.database().ref().child('LeaderBoard');
    if (defaultData)
        console.log("Found it sir")

    var playerScoreArr = [];
    var playerNameArr = [];


    var html = "";
    console.log(playerNameArr.length)
    defaultData.on('value', snap => {
        var scoreQuery = firebase.database().ref("LeaderBoard");
        scoreQuery.orderByChild('Player Score').once("value")
            .then(function (snapshot) {
                snapshot.forEach(function (childSnapshot) {
                    childSnapshot.forEach(function (finalShot) {
                        var childKey = finalShot.val();
                        //var childScore = finalShot.val();
                        playerNameArr.push(childKey);
                        //playerScoreArr.push(childScore);
                        //console.log(playerNameArr.length)
                    });
                });
                update_score();
            });

    })

    function update_score() {
        //console.log(playerNameArr)
        //console.log(playerNameArr.length)
        //snap.orderByKey().once("value").then(function (liastSnap) {
        //    listSnap.forEach(function (createList) {
        //        html += "<li>" + createList.child("Player Name").val() + " : " + createList.child("Player Score").val() + "</li>";
        //    })
        //})

        for (var i = playerNameArr.length - 1; i > 1; i-=2) {
            html += "<li>" + playerNameArr[i -1] + " : " + playerNameArr[i];
        }
        //console.log(html);
        playerNameArr.length = 0;
        playerScoreArr.length = 0;
        score_list.innerHTML = html;
        //console.log(playerScoreArr.length)
        html = "";
    }

}());