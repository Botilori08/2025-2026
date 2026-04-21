<?php


    $a=(float)$_GET["a"] ?? 0;
    $b=(float)$_GET["b"] ?? 0;

    //echo $a+$b;

    $muvelet = $_GET["muvelet"] ?? "";
    switch ($muvelet)
    {
        case "osszeadas":
            echo $a+$b;
            break;
        case "kivonas":
            echo $a-$b;
            break;
        case "szorzas":
            echo $a*$b;
            break;
        default:
            echo "Nincs művelet: ".$muvelet;
    }
?>