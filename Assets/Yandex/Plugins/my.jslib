mergeInto(LibraryManager.library, {

    RequestPlayerData: function () {
    	myGameInstance.SendMessage('YANDEX', 'SetName', player.getName());
    	myGameInstance.SendMessage('YANDEX', 'SetAvatar', player.getPhoto("medium"));
  	},
    
	RateGame: function () {
        ysdk.feedback.canReview()
            .then(({ value, reason }) => {
                if (value) {
                    ysdk.feedback.requestReview()
                        .then(({ feedbackSent }) => {
                            console.log(feedbackSent);
                        })
                } else {
                    myGameInstance.SendMessage('YANDEX', 'HideRadeBtn');
                }
            })
    },
    
    SaveExtern: function (date) {
        var dateString = UTF8ToString(date);
        var myobj = JSON.parse(dateString);
        player.setData({
            myobj
        }).then(() => {
            console.Log('data is Super set');
        });
    },

    LoadExtern: function () {
        player.getData().then(_date => {
            const myJSON = JSON.stringify(_date);
            myGameInstance.SendMessage('GameManager', 'SetPlayerData', myJSON);
        });
    },

    SetToLeaderboard: function (value) {
        ysdk.getLeaderboards()
        .then(lb => {
        lb.setLeaderboardScore('Score', value);
        });
    },
    
    GetLang: function () {
        var lang = ysdk.environment.i18n.lang;
        var bufferSize = lengthBytesUTF8(lang) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(lang, buffer, bufferSize);
        return buffer;
    },

    ShowAdv: function () {
        ysdk.adv.showFullscreenAdv({
            callbacks: {
                onClose: function (wasShown) {
                    // �������� ����� �������
                    myGameInstance.SendMessage('GameManager', 'PlayBackMusic');
                },
                onError: function (error) {
                    // some action on error
                    myGameInstance.SendMessage('GameManager', 'PlayBackMusic');
                }
            }
        })
    },


  });