# 数云net sdk
文档地址 https://open.shujuyingjia.com/#/apidoc

1. 可视化测试操作界面

![Image text](/res/1.png)



2.demo 会员注册示例
```
            string actionMethod = "shuyun.loyalty.member.register";//必须为POST方
            IClient client = new SYRestClient(config);
            string memberrRegisterJsonData = Newtonsoft.Json.JsonConvert.SerializeObject(memberrRegister);
            string result = client.PostRequestSnd(actionMethod, memberrRegisterJsonData);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ShuYunResult>(result);
```
