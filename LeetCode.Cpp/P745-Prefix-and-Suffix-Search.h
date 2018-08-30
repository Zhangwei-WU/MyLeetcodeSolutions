#pragma once

#include <vector>
#include <map>

namespace P745
{
	using namespace std;

	class TrieNode
	{
	public:
		TrieNode(int weight)
		{
			Next = new map<int, TrieNode*>();
			Weight = weight;
		}

		map<int, TrieNode*>* Next;
		int Weight;
	};

	class WordFilter {
	public:
		WordFilter(vector<string> words) 
		{
			BuildTrie(words);
		}

		int f(string prefix, string suffix) 
		{
			return GetMaxNode(trie, GetChars(prefix, suffix), 0);
		}

	private:

		vector<int> GetChars(const string& word)
		{
			int wordlen = word.size();
			vector<int> result;
			for (int j = 0; j < wordlen; j++)
			{
				result.push_back(word[j] - 'a');
				result.push_back(word[wordlen - j - 1] - 'a');
			}

			return result;
		}

		vector<int> GetChars(const string& prefix, const string& suffix)
		{
			int prefixlen = prefix.length();
			int suffixlen = suffix.length();
			int len = prefixlen > suffixlen ? prefixlen : suffixlen;
			vector<int> result;

			for (int i = 0; i < len; i++)
			{
				result.push_back(prefixlen <= i ? -1 : prefix[i] - 'a');
				result.push_back(suffixlen <= i ? -1 : suffix[suffixlen - i - 1] - 'a');
			}

			return result;
		}

		int GetMaxNode(TrieNode* trie, const vector<int>& sequence, int pos)
		{
			if (pos >= sequence.size()) return trie->Weight;
			else if (sequence[pos] == -1)
			{
				if (trie->Next->size() == 0) return -1;

				int max = -1;
				for (auto it : *trie->Next)
				{
					int val = GetMaxNode(it.second, sequence, pos + 1);
					if (val > max) max = val;
				}

				return max;
			}
			else
			{
				auto it = trie->Next->find(sequence[pos]);
				if (it == trie->Next->end()) return -1;
				return GetMaxNode(it->second, sequence, pos + 1);
			}
		}

		void BuildTrie(const vector<string>& words)
		{
			int len = words.size() - 1;
			trie = new TrieNode(len);

			for (int i = len; i >= 0; i--)
			{
				auto ptr = trie;
				for (auto c : GetChars(words[i]))
				{
					auto it = ptr->Next->find(c);
					TrieNode* next = nullptr;

					if (it == ptr->Next->end())
					{
						next = new TrieNode(i);
						ptr->Next->emplace(c, next);
					}
					else next = it->second;
					ptr = next;
				}
			}
		}

		TrieNode* trie;
	};
}