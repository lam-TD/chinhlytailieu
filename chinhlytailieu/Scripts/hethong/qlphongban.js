app.controller("qlphongController", function ($scope, $http) {
    $scope.nhomchucnang = "Quản lý người dùng";
    $scope.chucnang = "Quản lý phòng ban";

    $scope.lamdep = "lamtranduc";


    $scope.hienthicon = function () {
        var cq = document.getElementsByClassName('hienthicoquan');
        var cqcon = document.getElementsByClassName('coquancon');
        var madonvi = null;
        for (var i = 0; i < cq.length; i++) {
            cq[i].onclick = function () {
                for (var j = 0; j < cq.length; j++) {
                    cq[j].classList.remove("active-coquan");
                }
                this.classList.add("active-coquan");
                for (var i = 0; i < cqcon.length; i++) {
                    cqcon[i].style.display = "none";
                }
                madonvi = this.getAttribute("data-hienthi");
                $http({
                    method: 'POST',
                    url: '/hethong/ht_quanlyphong_loadBoPhanTheoCoQuan',
                    data: { madonvi: madonvi }
                }).then(function (response) {
                    $scope.listBoPhan = response.data;
                }, function (response) {
                    alert("Lỗi không tải được danh sách phòng");
                })
              
                for (var i = 0; i < cqcon.length; i++) {
                    var ht2 = cqcon[i].getAttribute("data-hienthi");
                    if (madonvi == ht2) {
                        cqcon[i].style.display = "block";
                    }
                }
            }
        }
    }

    $scope.clickcoquancon = function () {
        var cqc = document.getElementsByClassName('clickcoquancon');
        for (var i = 0; i < cqc.length; i++) {
            cqc[i].onclick = function () {
                var madonvi = this.getAttribute("data-madonvi");
                $http({
                    method: 'POST',
                    url: '/hethong/ht_quanlyphong_loadBoPhanTheoCoQuan',
                    data: { madonvi: madonvi }
                }).then(function (response) {
                    $scope.listBoPhan = response.data;
                })
            }
        }
    }

    


    


})

