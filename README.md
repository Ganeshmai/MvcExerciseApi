# MvcExerciseApi

MVC and API Course Exercise

-project Problem State-

[HttpGet]
api/category/getAll
[HttpGet]
api/category/getForId/{id}
[HttpPost]
api/category/insert/{category}
[HttpPost]
api/category/update/id/{id}/category/{category}
[HttpPost]
api/category/delete/{id}
====================================
[HttpGet]
api/product/getAll
[HttpGet]
api/product/getForId/{id}
[HttpPost]
api/product/save/{product json} //Handles both insert/update
[HttpPost]
api/product/delete/{id}

Step 2 : Table structure should be as below -
Category - Id, Name
Product - Id, Name, CategoryId, UnitId, Price
Unit – UnitId, Name


---------
This is Mvc web API project used store and retrive data from Db and do crud operations ,by relations of products ,category and units
which uses web ui to do operations and see.
