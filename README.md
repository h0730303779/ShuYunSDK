# 数云net sdk
文档地址 https://open.shujuyingjia.com/#/document/docs?docId=93

1. 可视化测试操作界面

![Image text](https://github.com/h0730303779/ShuYunSDK/blob/master/res/1.jpg)



2.demo 会员注册示例
```
            string actionMethod = "shuyun.loyalty.member.register";//请求接口名
            IClient client = new SYRestClient(config);//初始化配置
            string memberrRegisterJsonData = Newtonsoft.Json.JsonConvert.SerializeObject(memberrRegister);
            string result = client.PostRequestSnd(actionMethod, memberrRegisterJsonData); // 返回数云结果

```
