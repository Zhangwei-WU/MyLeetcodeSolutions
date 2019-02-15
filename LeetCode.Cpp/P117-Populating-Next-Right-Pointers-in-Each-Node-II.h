#pragma once

#include <stddef.h>

namespace P117
{
	struct TreeLinkNode
	{
		int val;
		TreeLinkNode *left, *right, *next;
		TreeLinkNode(int x) : val(x), left(NULL), right(NULL), next(NULL) {}

	};

	class Solution
	{
	public:
		void connect(TreeLinkNode *root)
		{
			if (root == NULL) return;

			if (root->left != NULL && (root->left->next = root->right) == NULL)
			{
				for (auto next = root->next; next != NULL; next = next->next)
				{
					if ((root->left->next = next->left) != NULL) break;
					if ((root->left->next = next->right) != NULL) break;
				}
			}

			if (root->right != NULL)
			{
				for (auto next = root->next; next != NULL; next = next->next)
				{
					if ((root->right->next = next->left) != NULL) break;
					if ((root->right->next = next->right) != NULL) break;
				}
			}

			connect(root->right);
			connect(root->left);
		}
	};
}
