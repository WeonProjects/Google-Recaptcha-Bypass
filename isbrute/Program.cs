using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace isbrute
{
    internal class Program
    {
        public static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            Console.WriteLine(GetRecaptchaTokenAsync().Result);
            Console.ReadKey();
        }
        public static async Task<string> GetRecaptchaTokenAsync()
        {
            MemoryStream str = new MemoryStream();

            var data = await client.GetStringAsync("https://www.google.com/recaptcha/api2/anchor?ar=1&k=6LfIfZEdAAAAANcxbLH8izj18olFscf20nu_zOju&co=aHR0cHM6Ly93d3cuaXRlbXNhdGlzLmNvbTo0NDM.&hl=tr&v=mq0-U1BHZ5YTcoDC-CvsLPNc&size=invisible&cb=bhj5acal78u1");

            Serializer.Serialize<ProtobufData>((Stream)str, new ProtobufData
            {
                A = "mq0-U1BHZ5YTcoDC-CvsLPNc",
                B = data.Split(new string[1] { "value=" }, StringSplitOptions.None)[1].TrimStart('"').Split('"')[0],
                C = "[81,77,37]",
                D = "!ExWgFRAKAAQeCcBhbQEHnAgETNmUwNVRbw227aYl7_waF0MYcre9Hq4kDaN3OTh7XR3zWKFEs_2rKUkSiAv4h3cQ4-xb0itVhulsY32y8up4SjqQ3Zif3k5A4En8Bs8Ub1sjQD1sX3YlUUftvr84lVwqawlZjwMG-S29rzYr9BouWzhrQauls4gSKYg-ifanyroNlUT8yZoVUV-y3GLtWtBCe7wXCwJQtmyX9hvNVSEsbwJ7zflMCj_NZTXkpFOrE9JJnMxAAyA-brmnG8zFOXx1OD-Sd3eliz3wpk3jx2VHgbiy1-ZJschjqPFK92WoUSWfTu_UdamWQLHsGVgcfIA4mCA6RcP2D-AXujxQKebhUZ9KPg5dQNcJ9oNPcXQzFzsWFk5CjbUDv9Pl_yE7hSmSwvcpK3LzOfrxdg7WRNEZIAbzTzTfX8I8eTbK2UlUA0bhqgTILnUtmIEf5OQFpb0rez_bcc8ihglgy1KfVR3chBAzle6ZhCH1kPIC7_SvqbTRnDXa1TqI0thXB1WMaCdFo8fax0JLLfGjxJp-Q5dN_rdfCrghq_oREHnU3wvA3stu1seYmx0QCuXOzNTi6j0W6nKbaWnNJMol0stgfU29YKT0U9gJ0N3Kb3ex4FT3Qqv8kHtydtGzb7gfD9ijCWFUPldTs9HRrQ01vRCrMThHDtsFiIlto-TZ5GTpINAImVzncx-2nB1JSr0DCR7c5-uYV_SC8NMQIsU4Bw11mZ-kjGlhY9K9z91su5n9QFrAI3xu790t3ZwXkaXRPWRLTpugJHnagSBWA69g3T_DcGBytlnPzfEiDiYwh1o7tgN7fDiTSLA8MzDVAN1Gc_x_UkKPlTE9aZXEEOnWwR6RkALteFv_eDF93jbh6I8O7F9Lybt8L2noQPDXuiSPtLeOrPkcbcrSLc61qJbh0Leb4sErhg_70uvwyfCVv4-PrHs-lWOQeHlNgBVyb1Q4l5U6d57BXY53wAKDd0Ruo1A7XT72YdLjRZxue7qlo60H9dHJw094cB4RvSmPbec9loguhZL6aKq8Ut7Be0iIRAhSQ3KqUnIzimXH1aGjkWmVSvBXZX55y9n9h7Eoie1icK2IN3uRtyK6C93aGVX9rpSBZUoGsANlHUJ6p3nFdSxG7Dq9ME4yRl9FBYjZpgvofQ70ORbLUBSHNC5PQ5rxVsPlFnUDcZ9hcq_6IC3EWqFeZJ8zoW5Y9IF7loe3p8jrzjp_Ko37eeuTNmHydQYpNkVg8vLxO-4jJmKjI_FgiL9uxIPnqGTIKETPFQ7f3H0FCf7sQvejhqNdj9XFNtZn3oaq2VCu6oSBEpaX7XWYavZjj96Tv7g5QZgiGm5TVWWSH4P4WBEk5XPSIZ04STnUGrGSe_9-UsPJX3hKjbiP2hGQbvETc-BcrXf_EaHAmaWovoAz1dajtGOnC2CmYjm4LXAbCr5RqVb8aIDultb7oyEPvZ2IDdO9ivTTxY6TbBJrkdLcv3JlhraZVJvUACdrCdragiALimPLuaKtvOu-0EVJREoVMXN3Uu7LKvRWQT0ipK6wK8h8nY3ROy8SXMZDS2OJXUvkVzdrS2HuAkiqzjSzpEunURsUnwLcg1gXmoiejyvBwzGhoTCDRCWocvW6L2uLzGcEomLMnvNVqt6wfQHJ0jnKAYHEgRBU_U_nxJmw8NG5ucn8jKbpiD0Tphw1IqTiKGlC8FGacNaSPNW6JJG3YraURvlSb04dni0vak930aKfR0j63pBb7Cwxk10ahxIxSzmA_TGcaeUb593LLjkw2tT2FjqyI2iHGBQyv6sr61N9oYznnqXIeMmiI0whk5hw-ICMep-bfqLjRrGs6iu7SvDjdjj36EYIrDkklQ8wKAyIRhyIyoNrBaVZ2g0HSU4FhT86Ce0GRFpMGvCA1VIlMquB_XNTZehlDvXR22Xuf3WTqDB7qU67pqgFieYJbrQH7C6vj27sLMQsILP34MGBV05Phxoz0yye1F2zK8J4azRiuPRHh2APH9szXdbPyHEfgu6csUGAtqm1UeLxsCJu1fPO4cyXuue1Kfzh92UOApWEas2GVYkGcJaX_q33vuNfeVEyI8K6p8-gu4GdAdIHbR-oOaEJcIcTd_5V24Zz92csv8qt3fu9Mv-7U2F3GAbJkEDbLhlAciUqBtbeufNQvyb_YKww3KcsJqdDah7_ahjzLxPxCYp0Uh2Pv4o9YFlT623B5NaXAICNOQT8Z0ZebYjzXmSIbi_96Y2BXX0hNA0NK_CKJVjoEsKQcCucC26ga4UwT3zA3FCNqI00KbKvgdZ1h4jIRXDRrWd4Fh_FkHLcKIo4RgaEOdIuVlEl65Bm8BWrpWjQdIDqWK91v93t-cXxh1yc-yOOfZ_aCOFXRlgMNuLmZrt_RpS7-vAyYEZiK_3eWqYmumMoIgMjvzJsX0HN3ApCe0yLbMUdlvF4yQfrdNzNimHt-6IwGbxpLWVHog_SwID0291eFZDd7wqEyYrGgcxeK8J99b7Ysm7TAW68mZZneyoAS1ojBytk_v2hnZo_dExz_r0fH-hPlkkc6ratxA_OJwvzU2UxaURwaJf1HbaHBJQGbbjzkFJE9ZZ0xJGvBERtN0ywfrA3QiktWVjG2VgDtgMdkMWnF_XIj0iHd5OUIxB-fMyJLgALoaAdU2OcjSVtq4HpudpcohishYqwOn3ynuc1eOY3LWGlBK6FpHvVgEIEspsfRkdt5QuscQzwnr4u6M0hmH889xsBh5voORGG1tox",
                E = "-2063528134",
                F = "q",
                G = "05AMjm62Vl6Uc-T2NsnegXCIf_EPGUVCt7qjmTQL91reLu77mEbX2OM7XyjVL1c-syq_SR6YhQUQJQsloLiUF5mg4LDOKnYf5baqSarm8h6-5RaHzw83yhMVBGUTntuhV2OdV29VExC_9Irkiv6haH7MyMWxqamgMbeW2yVKYXVPIzvCjwwe76wU5Yej_PY8pnputyq_BxNKhcNC0sj_-HqUwnS1OCTc5Oaq-KR9mQcz38WysIE0X6yFjOu3Nh57zKSCSSeFSq7nRgjwg29bk4rnNbtI156bDXc1GfaAW5uuvrT70KyCuAQjYS59UYfqcGdpDYrUOstif187HOsPLiWZzEFeC2cr2YZUDYW3earYbQXCJBRWJ_1apY4Ql5oogD09nYjJk58YeJ1961mbnDKflEL1noF5Q6uA",
                H = "user_login",
                I = "6LfIfZEdAAAAANcxbLH8izj18olFscf20nu_zOju",
                J = "0SUcn-7-MGSj8wI0aKf3Bjhsq_sKPHN_riFwl4LeKUWA0-MVSYTX5xlNiNvrHVGM3-8hVZDj8yVZlOf3KV2Y6_stYZzv_zFloPADNWmk9Ac5bV-sDkolUQMzFZzIx5LmgSDb9log5MuOYiDEP8q6gbCYLnWV8G8ydejQzwMhkNv7BumxbB-3blDwh-cdrbRz7oKFwE-CSaXhMEN1qeU0R3mt6ThLfbHtPE-BtfFAU4W59URXib35SFuNwf1MX5HFtAQ7Eqlcm-eiJhC8F8614FObJl2QxINa4ZUgSw5tiTOTQhX0-AszHUzkZ5MdlGgzwslBKLaV8Th_uun1PJPC8r0tH2-i2Umcv1ahZEOe7ilci6LqPWycatrJGUwLSqGxiKdaNaVUa9btoFu3Bk1st7sCVYS0gvLhMWSX4gFcp-8WSWCr_y5aKJiK2w3Q0EtjRYTUc96icaRvcz3Mg98mbZTX4yp9rNirGwlZjPu62pU445K-lNh4UwqR-JQHZhnUz6OCsUSvuoJJ0GdqxinYm-sBeNQfYqXU2CN2pdGgEAJShZEDIn3FFEuCgckcT3dJuav4LrHtSHxnwtVox2-iUYxAFy2g_E-CzekAS57KBcg4KnqtqThbRpIpGAfHFcj305pmSXAnEp2te1q2BTxvtroBVIO7gfHgMGdeTYUL7xnRLHe-2hUwe876MfhoWqrdrVt61h1ki8baIXSj16ISAFCHmwEgf88WKWSDyx5JeUu7qfotiBLKJXSn8wYpcMfzHvFhU6PW6lBzzx5leLfTGm2YxJsK-Ul8j_ZlmTCDPp6UxEQ7TmWM1zctqcvDHmWY5_9KcajcJ0pZoPQrXyGRg9AG6fGk-8rWLcxkJ2bNbTAXdhjpB6cO3T00Ho3aBPe-rpmML67qEQjQOu3N9U9jKpnEqHe6JchL0wJZFSiOacUUX3KtyRBnkr6RATyPntEE90d6OjRwoxcJ6Jf7FnX5JH-u1OxLktn5TE-W6hlRF4d1xfkMHpXxQIue2fU8k77qvS0fb6LdQQy3Us5FQ7AC_iTjvzsyHZATMpo9LIdeRf2AZ-p9cVjm_oJ8nFwisek34-J9qLC0GwphoJ_atlEYVCKaGcP3Ak39JOOS6pE8b3LSTWxX7xoMzELmQYjEByZ5oOATJm185BtLEYFzw_bCsJPvPmmo3_M6jbjkuytmtcT7Lx1toKunaqFA7w5ptOAnTo3U5D9miaUMQ3M5qZvoH54V6Qhu5cHYp-7qUZh_d4aZUEhS7hUAp-sWrZk7v14xpIvXumoAUIM6dWi8I9KuIShvErYsmI7CsTzYW2JFpVwjqulI--OHEXDHstrRwIC_Po1RZJu2ffk7qxrtrVSLSyWM9KPSZkyUFAJWZV__Pw284EeOHjDkm375GHfC7kVco9LyKVyrsxpNeUe3pfYpo-uC7kmcnw7eLSznzrn1uCdWneWc_1ZFPJvnFkmAx-sWUZzL1z5lhWvbyhpNLG_-HXjACyZZfMQbSn5EtKb3KeHnxyJxtOgDJm3A8CPuXpno-C5iUKDX4sYhvN-mnmlUo8NKFPyL2yIFYOtzLc2pP1um3UFL2xIVeBxCksE89AL90cyEawKSAE_Lcq1RXFei_aBYby3qLLPbytnpaKMuUYxYAvaB5W-DIrVxTGsvDfy0R9n-IVBi4rn5IDM-DYGIgtL2DLij6p4ha5N20hk4ctsyEWgu8vXojCdybhSMG98GcZw7UnG5K7fnBcDbu3rB_Ix4G0Vs_L-WTjycw0q50Nu_9jJpAJsPLXmsNCqyZcv4Gs5VMFN6lmkIX6MljaSDeo4B2_-LIljEL6reYKzT-nn52EQGol2b-_duBUgbu14szGuWibWgjB7qHXknUrHBVFQmknD5NEMx_cU7S4I5gGPLAhHRH6dawgj_ws4huRxHpj14n7-2OZD8R4pRbLgDApXQg29y6iUvf2JFyKNjFlktC3MCqdkwD8pJuExTyeGMrGayUfFoD7pRILCe_vnJe4-CYZDIq5oZlVSzFpms0AMyUTC8r8bdgYhbJn2pjHreXkkMqzLtsQzT_nIs2MuCXYzIsAZiHPhLcnH1U9vWgkGIK38p0Vw3GpJ9MEc_VlkkR87RuZRT_x3dICMGxjEAsv8mBTjf7uHMsK-GVcWU3AsWTSRrPxGhTAwrSh3Ys0KyVZBXJu61YR_GsjW8CFdKLcz324IhmAA7OmFEyBL6LbAsNpIY-S_jAilpB5OiyVBr0uKNNLAa1fz4n--FuhUjWw3NaPenMhXYp7KyPV070yHR4MyGqk3cr7birVw4fwLGCPhLtkosTGep0YCX83JR5GRTifE02Kq-fgUv53bByX_yspFsdKs2sXSj4tn6VLObqsoxh-_2niWHot8JjZdqxg1cg8bKEUB0Xs69DUAjdpnBSDeGqhzHftopcIfC3iV4p9OmFgRUi0MR8bhvjxnU8BtW_dV8r2rRuLAj1n19wGeG5bVI91dl-S_gI0IBiJ-i3f2MrxtN_PzXcpoorM_HHh0U05ZamRC8Rqak2O_CpiWkZz6-vOEb21YxLEuTjqzkZ7K57SB4IuqVMJwXDlD8hF7SGS0T0v4F1COrCf4UP_qSlezwd4pJZRwbplXcQ6riDd1L33KqGQBXqhkcfD-mmilMjr7x6L_yrj3wi4byqWCgjyqt3KRvCoEoZ9tOlZ0cdr65vOxj0hF4xKdqiil8P1rpROunVmmBVBcuzi0rup35QIuu-f1Em8buxTUnd6q5pUOnWnWVqLMu8VT8ovcBYbBAEo3JIKtvUl0LjuoxcLvvIjlkt-8iJYzD87oqGGifhwW0b8sSVZC_zxZplLyXBvVFeLcjHqG4s_q2UMBvKnqxjA-XQp1VCB9SpcyX1mHhXNsmir1E39uNscBTmrrBpQPHgnl1DCdGRNAYFwnR8Je6jiH1D2qdqgfnQonVDDNGjeEMNA5-bLzz57pNxPOy6loIhIPCHVxUT7HRqUfO7h2s13cuHVTICr69sWQDDeUlNBuWTSzf8xZtvNdOqfk0e5Kt9Uh3n3Xl1CRbllXI__7e4lDYjz5RmX-z4vZBgB76KcyICyZdrQP_6loJREe3GdWcC08OJIwTav4hLFt2bm2s0vsSUR_bwyI1p7vefeT8m86CLaAnV1phiC9PJoD052dOWXQvoyX4tCdXFf0M0CKSBairIl1Ip-86VYyr80ZxlXPj0iJVkD96cd0Lwx5lrNv_Imm86A_qWaDsH1aJtMS3BzoJ1S_WgkHs8ALWjUUrryKYrAtSldDsD1ap1PjXRzWFPJv7et2YMDuuOVSHaz7B7SAPdgE3_1q55RxPeqXxEF9iyf0s92dVpdk3_8sBcJPfFoIpW4MqOSyf-6Ix9SufXrVtN-NSaXCoJyLhfTPzGnI9XCfZySRvttINKHPG8hHwYFKi1Z2My0ZVnZe7NqGxQC82ZcFse_sR9IzbypXdV88KomVkM5o-bFu2_kVsq7sCVYCggvLhMWRnHsG5kH8bFj2sV6dVdLPTYr5U8Qum0mHT55JqcUzbPup1DGwqYfHgjBbCoVhoUsal6Oemggk1EAM-QUgHN4mxZOwKdhjUzEduzcQvswad8JxvTaHlB68BtXUXtsm2AQfPDp1Ek7cCmbxIgxYh4SPzqknggIcx4gzXiq6J1JBXhZj0P4q1-PhDcqaM_O8_ckIJVEMZ5iUb8xMJMW_HXrWte9NONfzD5oXhKHeSxeUsg6rmrR0PX5JyOWhD4h4kyBPCYZTYOvJmGWxHWhGRDDNTHhGYHwYVVPDX1p3AhNL2lkFzgt4laKfC4il8p9-qGgk8csHt2ZDavnWQ4NfHLjhnws5dkGiK-uk48LgXPmmM8AYNaHfnFllFZ9fGFcm8rDclTKu3JlWYhKfaSmWE5DcxgIyUE1plxRg-Lky8r-sc"
            }); // You can find out the data and its values ​​through Charles. // Üstteki verilerin değerlerini API'ye göre düzenleyin.

            ByteArrayContent bt = new ByteArrayContent(str.ToArray());
            bt.Headers.TryAddWithoutValidation("Content-Type", "application/x-protobuffer");
            var resp = await client.PostAsync("https://www.google.com/recaptcha/api2/reload?k=6LfIfZEdAAAAANcxbLH8izj18olFscf20nu_zOju", bt).Result.Content.ReadAsStringAsync();

            return resp.ToString().Split(',')[1].Replace("\"", "");
        }

        [ProtoContract(SkipConstructor = true)]
        internal class ProtobufData
        {
            [ProtoMember(1)]
            public string A { get; set; }

            [ProtoMember(2)]
            public string B { get; set; }

            [ProtoMember(3)]
            public string C { get; set; }

            [ProtoMember(4)]
            public string D { get; set; }

            [ProtoMember(5)]
            public string E { get; set; }

            [ProtoMember(6)]
            public string F { get; set; }

            [ProtoMember(7)]
            public string G { get; set; }

            [ProtoMember(8)]
            public string H { get; set; }

            [ProtoMember(14)]
            public string I { get; set; }
            [ProtoMember(16)]
            public string J { get; set; }
        }
    }
}
