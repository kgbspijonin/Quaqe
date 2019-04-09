using System.Collections;
using System;
using System.Text;
using System.Collections.Generic;

public class LobbyInfo {
    public string name = "Lobby name";
    public string ip = "localhost";
    static private string delimiter = "//";
    static private string chainDelimiter = "/-/";

    public string Delimiter {
        get {
            return delimiter;
        }
    }

    public string ChainDelimiter {
        get {
            return chainDelimiter;
        }
    }

    public void FromString(string s)
    {
        name = s.Substring(0, s.IndexOf(delimiter));
        s = s.Substring(s.IndexOf(delimiter) + delimiter.Length);
        ip = s;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append(name);
        result.Append("\\");
        result.Append("ip");
        return result.ToString();
    }

    static public LobbyInfo ParseFromString(string s)
    {
        LobbyInfo lobby = new LobbyInfo();
        lobby.name = s.Substring(0, s.IndexOf(delimiter));
        s = s.Substring(s.IndexOf(delimiter) + delimiter.Length);
        lobby.ip = s;
        return lobby;
    }

    static public string ChainLobbyInfo(params LobbyInfo [] lobbies)
    {
        StringBuilder sb = new StringBuilder();
        foreach(LobbyInfo li in lobbies)
        {
            sb.Append(li.ToString());
            sb.Append(chainDelimiter);
        }
        return sb.ToString();
    }

    static public List<LobbyInfo> UnchainLobbyInfo(string s)
    {
        List<LobbyInfo> lobbies = new List<LobbyInfo>();
        while(s.Length > 0)
        {
            lobbies.Add(ParseFromString(s.Substring(0, s.IndexOf(chainDelimiter))));
            s = s.Substring(s.IndexOf(chainDelimiter) + chainDelimiter.Length);
        }
        return lobbies;
    }
}
