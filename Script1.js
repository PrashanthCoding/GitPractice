<html>
<head>
    <title> Using the strict mode gloablly </title>
</head>
<body>
    <script>
        x = 100; // This is valid
        document.write("The value of the X is - " + x);
        function test() {
            "use strict";
            y = 50; // This is not valid
            document.write("The value of the y is: " + x);
        }
        test();
    </script>
</body>
</html>
