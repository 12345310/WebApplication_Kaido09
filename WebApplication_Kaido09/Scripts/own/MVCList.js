$(function () {

    // チェックボックスの状態をchangeイベントで監視
    $('[name="item.DoneFlg"]').change(function (ele) {
        // チェック状態を取得
        var checkFlg = !!ele.target.checked;
        // チェンジイベントが走ったデータのIDを取得
        var intId = parseInt(ele.target.id);

        var param = {
            Id: intId,
            DoneFlg: checkFlg
        }

        $.ajax({
            url: '/MVCLists/Check1',
            type: "POST",
            dataType: "json",
            data: param
        })
    })
});