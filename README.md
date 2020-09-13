# OrderInformationWebApi

This is an Asp.Net Core Web application Project.
It parses text files having order details saved under path -
D:\Github-Workspace\OrderInformationWebApi\src\OrderService\Resources
and serializes it in xml form saves the generated xml to above path.

The Api has two following endpoints to get order details from generated xml file,
order details are exponsed in JSON form.

1. HTTP GET - Get order details of all orders.
2. HTTP GET - Get order details of an order by OrderNumber.