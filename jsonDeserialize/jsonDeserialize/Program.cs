using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using jsonDeserialize;

string payload = """        
    {
      "responses": [
        {
          "command": "listClients",
          "data": {
            "totalCount": 1,
            "clients": [
              {
                "username": "admin",
                "textname": "Dynsec admin user",
                "roles": [
                  {
                    "rolename": "admin"
                  }
                ],
                "groups": []
              }
            ]
          }
        },
        {
          "command": "listGroups",
          "data": {
            "totalCount": 0,
            "groups": []
          }
        },
        {
          "command": "listRoles",
          "data": {
            "totalCount": 1,
            "roles": [
              {
                "rolename": "admin",
                "acls": [
                  {
                    "acltype": "publishClientSend",
                    "topic": "$CONTROL/dynamic-security/#",
                    "priority": 0,
                    "allow": true
                  },
                  {
                    "acltype": "publishClientReceive",
                    "topic": "$CONTROL/dynamic-security/#",
                    "priority": 0,
                    "allow": true
                  },
                  {
                    "acltype": "publishClientReceive",
                    "topic": "$SYS/#",
                    "priority": 0,
                    "allow": true
                  },
                  {
                    "acltype": "publishClientReceive",
                    "topic": "#",
                    "priority": 0,
                    "allow": true
                  },
                  {
                    "acltype": "subscribePattern",
                    "topic": "$CONTROL/dynamic-security/#",
                    "priority": 0,
                    "allow": true
                  },
                  {
                    "acltype": "subscribePattern",
                    "topic": "$SYS/#",
                    "priority": 0,
                    "allow": true
                  },
                  {
                    "acltype": "subscribePattern",
                    "topic": "#",
                    "priority": 0,
                    "allow": true
                  },
                  {
                    "acltype": "unsubscribePattern",
                    "topic": "#",
                    "priority": 0,
                    "allow": true
                  }
                ]
              }
            ]
          }
        }
      ]
    }
    """;


//payload = @"{ ""responses"":[""a"",""b"",""c""]}";

var jsonoptions = new JsonSerializerOptions
{
    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin),
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};

var data = JsonSerializer.Deserialize<Teste>(payload, jsonoptions);
Console.Out.WriteLine("fim");
