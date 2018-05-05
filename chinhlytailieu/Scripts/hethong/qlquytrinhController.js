﻿app.controller("qlquytrinhController", function ($scope, $http) {
    $scope.nhomchucnang = "Quản lý người dùng";
    $scope.chucnang = "Quản lý phòng ban";

    $scope.btn_disable = true;
    $scope.flag = true; // co bao giu hay xoa $scope.qt
    $scope.txtdisable = false;

    // load loai quy trinh
    $http({
        method: 'GET',
        url: '/hethong/thqt_LoadLoaiQT'
    }).then(function (response) {
        $scope.listLoaiQuyTrinh = response.data;
    })

    $scope.loadloaiQT = function () {
        $http({
            method: 'GET',
            url: '/hethong/thqt_LoadLoaiQT'
        }).then(function (response) {
            $scope.listLoaiQuyTrinh = response.data;
        })
    }

    // click loai quy trinh
    $scope.click_loaiQT = function (qt) {
        $scope.btn_disable = false;
        var q = document.getElementsByClassName('clickLQT');
        for (var i = 0; i < q.length; i++) {
            q[i].onclick = function () {
                for (var j = 0; j < q.length; j++) {
                    q[j].classList.remove("active_nhom");
                }
                this.classList.add("active_nhom");
            }
        }

        var qtt = {
            maloai: qt.MALOAI,
            tenloai: qt.TENLOAI,
            thuphi: qt.THUPHI
        }
        $scope.qt = qtt;
    }

    // click modal them-sua
    $scope.modal = function (state) {
        $scope.state = state;
        if (state == "add") {
            if ($scope.flag) {
                $scope.qt = null;
            }
        }
        else {
            $scope.txtdisable = true;
        }
        
    }

    // them -sua loai quy trinh
    $scope.checkLoaiQuyTrinh = function (maloai) {
        $http({
            method: 'POST',
            url: '/hethong/thqt_CheckMaLoaiQT',
            data: { maloai: maloai }
        }).then(function (response) {
            if (response.data == "1") {
                alert("Thêm thành công");
                $scope.flag = true;
            }
            else { alert("Lỗi không thêm được"); $scope.flag = false; }
        }, function () {
            alert("Lỗi không thực được chức năng");
        })
    }

    $scope.save = function (state) {
        if (state == "add") {
            $http({
                method: 'POST',
                url: '/hethong/thqt_ThemSuaQT',
                data: { type: 1, qt: $scope.qt }
            }).then(function (response) {
                if (response.data == "1") {
                    alert("Thêm thành công");
                    $scope.flag = true;
                    $scope.loadloaiQT();
                }
                else if (response.data == "2") {
                    alert("Mã loại đã tồn tại vui lòng nhập Mã Loại KHÁC");
                    $scope.flag = false;
                }
                else { alert("Lỗi không thêm được"); $scope.flag = false; }
            }, function () {
                alert("Lỗi không thực được chức năng");
            })
        }
        else if (state == "edit") {
            var conf = confirm("Bạn có chắc chắn muốn cập nhật Quy Trình vừa chọn");
            if (conf) {
                $http({
                    method: 'POST',
                    url: '/hethong/thqt_ThemSuaQT',
                    data: { type: 2, qt: $scope.qt }
                }).then(function (response) {
                    if (response.data == "1") {
                        alert("Cập nhật thành công");
                        $scope.loadloaiQT();
                    }
                    else { alert("Lỗi không cập nhật được"); }
                }, function () {
                    alert("Lỗi không thực được chức năng");
                })
            }
        }
    }

    // xoa
    $scope.delete = function () {
        conf = confirm("Bạn có chắc chắn muốn xóa Loại Quy Trình vừa chọn?");
        if (conf) {
            $http({
                method: 'POST',
                url: '/hethong/thqt_XoaLoaiQuyTrinh',
                data: { maloai: $scope.qt.maloai }
            }).then(function (response) {
                if (response.data == "1") {
                    alert("Đã XÓA quy trình có Mã Loại: " + $scope.qt.maloai);
                    $scope.loadloaiQT();
                }
                else if(response.data == "2"){
                    alert("Bạn cần xóa những trường liên quan đến Mã Loại : " + $scope.qt.maloai);
                }
                else { alert("Lỗi Xóa thêm được"); $scope.flag = false; }
            }, function () {
                alert("Lỗi không thực được chức năng");
            })
        }
    }
})

